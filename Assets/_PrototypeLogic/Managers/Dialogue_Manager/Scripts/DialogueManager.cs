using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace PrototypeLogic.Dialogue_Manager
{
    [CreateAssetMenu(menuName = "Game Managers/Dialogue_Manager", fileName = "New Dialogue_Manager")]
    public class DialogueManager : BaseManager
    {
        [SerializeField] private DialogueController DialogueControllerPrefab;
        [SerializeField] private Dialogue[] Dialogues;

        private Dictionary<DialogueTitle, Dialogue> DialoguesGroup = new Dictionary<DialogueTitle, Dialogue>();
        private static DialogueManager Instance;

        private DialogueController CurrentDialogueController { get; set; }

        public static Dialogue GetDialogue(DialogueTitle name) => Instance.DialoguesGroup[name];

        public override void Initialize()
        {
            if (Instance != null) return;
            Instance = this;

            foreach (var dialogue in Instance.Dialogues)
            {
                Instance.DialoguesGroup.Add(dialogue.GetTitle, dialogue);
            }
            
            Debug.Log("DialogueManager Initialized");
        }

        public static void StartDialogue(DialogueTitle dialogueTitle, Action OnDialogueStartedAction = null, Action OnDialogueFinishedAction = null)
        {
            if (Instance.CurrentDialogueController != null || !Instance.DialoguesGroup.ContainsKey(dialogueTitle))
            {
                Debug.LogError("DialoguesGroup NOT ContainsKey or CurrentDialogueController is NULL");
                return;
            }
            Instance.CurrentDialogueController = Instantiate(Instance.DialogueControllerPrefab);
            Instance.CurrentDialogueController.OnDialogueStarted += OnDialogueStartedAction;
            Instance.CurrentDialogueController.OnDialogueFinished += OnDialogueFinishedAction;
            Instance.CurrentDialogueController.Initialize(dialogueTitle);
        }
    }
}