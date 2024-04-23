using UnityEngine;
using PrototypeLogic.UI_Manager;

public class GameLevelStartup : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            UIManager.Instance.Show(WindowTypes.GamePause);
    }
}
