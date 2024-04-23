using UnityEngine;
using PrototypeLogic.UI_Manager;

public class MainMenuLevelStartup : MonoBehaviour
{

    private void Start()
    {
        UIManager.Instance.Show(WindowTypes.MainMenu);
    }
}
