using PrototypeLogic.Game_Manager;
using UnityEngine;

namespace PrototypeLogic.Task_Manager
{
    [AddComponentMenu("Prototype_Logic/Task_Manager/TaskTrigger3D")]
    public class TaskTrigger3D : TaskTriggerBase
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerController>())
            {
                IsPlayerEnteredTrigger = true;
                Debug.Log("PopupManager.Show(ChapterTask_Popup)");
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<PlayerController>())
            {
                IsPlayerEnteredTrigger = false;
                Debug.Log("PopupManager.Hide(ChapterTask_Popup)");
            }
        }
    }
}