using UnityEngine;

namespace PrototypeLogic.Dialogue_Manager
{
    public class DialogueData : MonoBehaviour
    {
        public Dialogue[] FDialogue;
    }

    [System.Serializable]
    public class Dialogue
    {
        public DialoguePhrase[] FDialoguePhrase;
    }
    
    [System.Serializable]
    public class DialoguePhrase
    {
        public CharacterNames FDialogueConversator;
        [TextArea (maxLines:10,minLines:3)] public string FPhrase;
    }
}
