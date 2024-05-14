namespace PrototypeLogic.Dialogue_Manager
{
    public class ImmediateTypingBehavior : ITypingBehavior
    {
        public void TextTyping(string typingText, TMPro.TextMeshProUGUI textContainer)
        {
            textContainer.text = typingText;
        }
    }
}