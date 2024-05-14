using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace PrototypeLogic.Dialogue_Manager
{
    public class DialogueManager : BaseManager
    {
        [SerializeField] private DialogueController DialogueControllerPrefab;
        [SerializeField] private Dialogue[] Dialogues;

        private Dictionary<DialogueTitle, Dialogue> DialoguesGroup =
            new Dictionary<DialogueTitle, Dialogue>();

        public Dialogue GetDialogue(DialogueTitle name) => DialoguesGroup[name];

        public static DialogueManager Instance;

        private DialogueController CurrentDialogueController { get; set; }

        public override void Initialize()
        {
            if (Instance != null) return;
            Instance = this;

            foreach (var dialogue in Dialogues)
            {
                DialoguesGroup.Add(dialogue.GetTitle, dialogue);
            }
            
            Debug.Log("DialogueManager Initialized");
        }

        public void StartDialogue(DialogueTitle dialogueTitle, Action OnDialogueStartedAction = null, Action OnDialogueFinishedAction = null)
        {
            if (CurrentDialogueController != null || !DialoguesGroup.ContainsKey(dialogueTitle))
            {
                Debug.LogError("DialoguesGroup NOT ContainsKey or CurrentDialogueController is NULL");
                return;
            }
            CurrentDialogueController = Instantiate(DialogueControllerPrefab);
            CurrentDialogueController.OnDialogueStarted += OnDialogueStartedAction;
            CurrentDialogueController.OnDialogueFinished += OnDialogueFinishedAction;
            CurrentDialogueController.Initialize(dialogueTitle);
        }
    }
}