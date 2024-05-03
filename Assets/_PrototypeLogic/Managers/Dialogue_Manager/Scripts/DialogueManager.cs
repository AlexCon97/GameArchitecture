using System;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeLogic.Dialogue_Manager
{
    public class DialogueManager : BaseManager
    {
        [SerializeField] private DialogueController FDialogueControllerPrfab;
        [SerializeField] private DialogueData FDialogueData;
        [SerializeField] private List<DialogueConversator> FDialogueConversatorGroup;
        
        public static DialogueManager FInstance;

        public DialogueData GetData() => FDialogueData;
        public Dictionary<CharacterNames,Sprite> GetDialogueConversator { get; private set; }
        
        public override void Initialize()
        {
            Singleton();
            GetDialogueConversator = new Dictionary<CharacterNames, Sprite>();
            foreach (var conversator in FDialogueConversatorGroup)
            {
                GetDialogueConversator.Add(conversator.FName, conversator.FSprite);
            }
        }

        private void Singleton()
        {
            if (FInstance != null) return;
            FInstance = this;
        }
        
        public void StartDialog(int dialogueIndex, Action OnDialogueStartedAction, Action OnDialogueFinishedAction)
        {
            var dialogController = Instantiate(FDialogueControllerPrfab);
            if (OnDialogueStartedAction != null) dialogController.OnDialogueStarted += OnDialogueStartedAction;
            if (OnDialogueFinishedAction != null) dialogController.OnDialogueFinished += OnDialogueFinishedAction;
            dialogController.Initialize(dialogueIndex);
        }
    }

    [Serializable]
    public class DialogueConversator
    {
        public CharacterNames FName;
        public Sprite FSprite;
    }
    
    public enum CharacterNames
    {
        None
    }
}
