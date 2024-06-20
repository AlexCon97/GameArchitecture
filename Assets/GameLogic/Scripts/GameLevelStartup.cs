using UnityEngine;
using PrototypeLogic.UI_Manager;
using PrototypeLogic.Task_Manager;
using PrototypeLogic.Game_Manager;

public class GameLevelStartup : MonoBehaviour
{
    private void Awake()
    {
        TaskManager.ShowOrInitializeTaskTrigger(5);
        HUD.Active();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TaskManager.ReloadTask();
            //UIManager.Show(WindowTypes.GamePause);
        }
    }
}
