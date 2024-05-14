using UnityEngine;
using PrototypeLogic.UI_Manager;
using PrototypeLogic.Dialogue_Manager;

public class MainMenuLevelStartup : MonoBehaviour
{

    private void Start()
    {
        //UIManager.Instance.Show(WindowTypes.MainMenu);
        DialogueManager.Instance.StartDialogue(DialogueTitle.DialogueTitle1,
            () => Debug.Log("LETS CONVERSATION"),
            () => Debug.Log("START TASK"));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            DialogueManager.Instance.StartDialogue(DialogueTitle.DialogueTitle2,
            () => Debug.Log("LETS CONVERSATION"),
            () => Debug.Log("START TASK"));
    }
}
