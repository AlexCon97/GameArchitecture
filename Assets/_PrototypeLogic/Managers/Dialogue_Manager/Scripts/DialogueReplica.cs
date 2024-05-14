using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeLogic.Dialogue_Manager
{
    [System.Serializable]
    public struct DialogueReplica
    {
        [SerializeField] private DialogueCharacter DialogueCharacterObject;
        [TextArea][SerializeField] private string DialoguePhrase;

        public DialogueCharacter GetDialogueCharacter => DialogueCharacterObject;
        public string GetDialoguePhrase => DialoguePhrase;
    }
}