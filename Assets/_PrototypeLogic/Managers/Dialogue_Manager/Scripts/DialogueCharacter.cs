using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeLogic.Dialogue_Manager
{
    [CreateAssetMenu(menuName = "Dialogue_Manager/DialogueCharacter", fileName = "New_DialogueCharacter")]
    public class DialogueCharacter : ScriptableObject
    {
        [SerializeField] private string CharacterName;
        [SerializeField] private Sprite CharacterSprite;

        public string GetName => CharacterName;
        public Sprite GetSprite => CharacterSprite;
    }
}