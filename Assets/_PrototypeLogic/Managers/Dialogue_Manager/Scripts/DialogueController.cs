using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PrototypeLogic.Dialogue_Manager
{
    public class DialogueController : MonoBehaviour
    {
        [SerializeField] private Image DialogueCharacterImage;
        [SerializeField] private TMPro.TextMeshProUGUI DialogueCharacterName;
        [SerializeField] private TMPro.TextMeshProUGUI TextContainer;
        [SerializeField] private Button TapPlace;
        [SerializeField] private Button SkipButton;

        private ITypingBehavior typingBehavior;
        private Dialogue currentDialogue;
        private int currentReplicaIndex;

        public Action OnDialogueStarted;
        public Action OnDialogueFinished;

        public void Initialize(DialogueTitle dialogueTitle)
        {
            SetTypingBehavior(new ImmediateTypingBehavior());
            currentDialogue = DialogueManager.Instance.GetDialogue(dialogueTitle);
            TapPlace.onClick.AddListener(NextReplica);
            SkipButton.onClick.AddListener(SkipDialogue);

            StartDialogue();
        }

        private void StartDialogue()
        {
            Debug.Log("Start dialogue");
            TextTyping();
            OnDialogueStarted?.Invoke();
        }
        private void FinishDialogue()
        {
            Debug.Log("End");
            OnDialogueFinished?.Invoke();
            Destroy(gameObject);
        }
        private void SkipDialogue()
        {
            Debug.Log("Skipped");
            FinishDialogue();
        }

        public void SetTypingBehavior(ITypingBehavior typingBehavior) =>
            this.typingBehavior = typingBehavior;

        private void NextReplica()
        {
            currentReplicaIndex++;
            TextTyping();
        }

        private void TextTyping()
        {
            var isDialogEnd = currentReplicaIndex >= currentDialogue.GetReplicas.Count;
            if (isDialogEnd)
            {
                FinishDialogue();
                return;
            }

            typingBehavior.TextTyping(
                currentDialogue.GetReplicas[currentReplicaIndex].GetDialoguePhrase,
                TextContainer);

            //TextContainer.text = currentDialogue.GetReplicas[currentReplicaIndex].GetDialoguePhrase;
            DialogueCharacterName.text = currentDialogue.GetReplicas[currentReplicaIndex].GetDialogueCharacter.GetName.ToString();
            DialogueCharacterImage.sprite = currentDialogue.GetReplicas[currentReplicaIndex].GetDialogueCharacter.GetSprite;
        }

    }
}