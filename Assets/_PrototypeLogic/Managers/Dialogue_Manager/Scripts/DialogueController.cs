using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PrototypeLogic.Dialogue_Manager
{
    public class DialogueController : MonoBehaviour
    {
        [SerializeField] private TMP_Text FTextContainer;
        [SerializeField] private float FTextDelay;
        [SerializeField] private Button FDialogueTapPlace;
        [SerializeField] private Image FLeftDialogueConversator;
        [SerializeField] private Image FRightDialogueConversator;
        [SerializeField] private RectTransform FDialogueBubble;

        public Action OnWriteTextStarted;
        public Action OnWriteTextFinished;
        public Action OnDialogueStarted;
        public Action OnDialogueFinished;

        private IEnumerator _routine;
        private float _currentTextDelay;
        private int _currentPhraseIndex;
        private int _currentDialogIndex;
        private bool _isTextTyping;
        private bool _isDialogFinished;
        private int _conversatorAmountOnScene = 2; //conversator images on scene by one dialog
        private float _startFontSize;
        private int _wordPhraseIndex;
        private string[] _phraseWords;

        public void Initialize(int dialogIndex)
        {
            FDialogueTapPlace.onClick.AddListener(Taped);
            //OnWriteTextStarted += TextTypingStart;
            //OnWriteTextFinished += TextTypingFinish;
            //OnDialogueStarted += DialogStart;
            //OnDialogueFinished += DialogFinish;
            OnDialogueFinished += () => Destroy(gameObject);
            
            OnDialogueStarted?.Invoke();
            _currentPhraseIndex = 0;
            _currentDialogIndex = dialogIndex;
            _startFontSize = FTextContainer.fontSize;
            _currentTextDelay = FTextDelay;
            StartWriteText();
        }
        
        private void DialogStart()
        {
            //Debug.Log("Dialog Started");
        }

        private void DialogFinish()
        {
            //FTextContainer.text += "\nDialog Finished";
            //Debug.Log("DIALOG FINISHED");
        }

        private void TextTypingStart()
        {
            //Debug.Log("Text Typing Started");
        }

        private void TextTypingFinish()
        {
            //Debug.Log("Text Typing Finished");
        }

        private void Taped()
        {
            if (_isTextTyping) _currentTextDelay = 0;
            else if (!_isTextTyping && !_isDialogFinished) StartWriteText();
            else OnDialogueFinished?.Invoke();
        }
        
        private void StartWriteText()
        {
            _routine = WriteText();
            StartCoroutine(_routine);
            _isTextTyping = true;
            
            // Change Dialog Sprite
            var dialogPhrase = DialogueManager.FInstance.GetData().FDialogue[_currentDialogIndex].FDialoguePhrase;
            if (_currentPhraseIndex % _conversatorAmountOnScene == 0 && !_isDialogFinished)
            {
                FLeftDialogueConversator.sprite =
                    DialogueManager.FInstance.GetDialogueConversator[
                        dialogPhrase[_currentPhraseIndex].FDialogueConversator];
            }
            else if (_currentPhraseIndex % _conversatorAmountOnScene != 0 && !_isDialogFinished)
            {
                FRightDialogueConversator.sprite =
                    DialogueManager.FInstance.GetDialogueConversator[
                        dialogPhrase[_currentPhraseIndex].FDialogueConversator];
            }

            //Change DialogueBubble scale (rotate to another conversator)
            if (_wordPhraseIndex == 0)
            {
                var newBubbleScale = FDialogueBubble.localScale;
                newBubbleScale.x *= -1;
                FDialogueBubble.localScale = newBubbleScale;
            }

            OnWriteTextStarted?.Invoke();
        }
        
        
//        private void StopWriteText()
//        {
//            currentTextDelay = 0;
//            //StopCoroutine(routine);
//            //routine = WriteText(false);
//            //StartCoroutine(routine);
//            //StartCoroutine(WriteText(false));
//            //FTextContainer.text = DialogueManager.FInstance.GetData().FDialogue[currentDialogIndex].FDialoguePhrase[currentPhraseIndex].FPhrase;
//
//            //FinishWriteText();
//        }

        private void FinishWriteText()
        {
            //if end word in the phrase, start wordPhraseIndex from zero, set next phraseIndex
            if (_wordPhraseIndex == _phraseWords.Length - 1)
            {
                _wordPhraseIndex = 0;
                _currentPhraseIndex++;
            }

            _isTextTyping = false;
            _routine = null;
            _currentTextDelay = FTextDelay;
            OnWriteTextFinished?.Invoke();
            _isDialogFinished = _currentPhraseIndex ==
                                    DialogueManager.FInstance.GetData().FDialogue[_currentDialogIndex].FDialoguePhrase.Length;

            if (_isDialogFinished)
            {
                _currentDialogIndex++;
                _currentPhraseIndex = 0;
            }
        }
        
        private IEnumerator WriteText()
        {
            //clear textContainer, set fontSize to startSize
            FTextContainer.text = "";
            FTextContainer.fontSize = _startFontSize;
            
            _phraseWords = DialogueManager.FInstance.GetData().FDialogue[_currentDialogIndex]
                .FDialoguePhrase[_currentPhraseIndex].FPhrase.Split(' ');
            
            for (int i = _wordPhraseIndex; i < _phraseWords.Length; i++)
            {
                _wordPhraseIndex = i;

                //max words in text container, because font can 
                if (FTextContainer.fontSize < _startFontSize)
                {
                    Debug.Log("WIi");
                    _wordPhraseIndex = i;
                    break;
                }

                //Flag-word in the dialogue for stop writing
                if (_phraseWords[i]=="/END/")
                {
                    Debug.Log("WIi");
                    _wordPhraseIndex = i+1;
                    break;
                }

                //typing letters
                foreach (var letter in _phraseWords[i])
                {
                    FTextContainer.text += letter;
                    yield return new WaitForSeconds(_currentTextDelay);
                }
                //typing space, because phraseWords[i] without spaces
                FTextContainer.text += ' ';
                
            }

            FinishWriteText();
        }

        private void OnDestroy()
        {
            FDialogueTapPlace.onClick.RemoveListener(Taped);
            //if (OnWriteTextStarted != null) OnWriteTextStarted -= TextTypingStart;
            //if (OnWriteTextFinished != null) OnWriteTextFinished -= TextTypingFinish;
            //if (OnDialogueStarted != null) OnDialogueStarted -= DialogStart;
            if (OnDialogueFinished != null)
            {
                //OnDialogueFinished -= DialogFinish;
                OnDialogueFinished -= () => Destroy(gameObject);
            }
        }
    }
}
