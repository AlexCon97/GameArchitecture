using UnityEngine;

namespace PrototypeLogic.Task_Manager
{
    [AddComponentMenu("Prototype_Logic/Task_Manager/TaskTrigger2D")]
    public sealed class TaskTrigger2D : TaskTriggerBase
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PlayerController>())
            {
                IsPlayerEnteredTrigger = true;
                OnTriggerEntered?.Invoke();
                Debug.Log("PopupManager.Show(ChapterTask_Popup)");
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.GetComponent<PlayerController>())
            {
                IsPlayerEnteredTrigger = false;
                OnTriggerExited?.Invoke();
                Debug.Log("PopupManager.Hide(ChapterTask_Popup)");
            }
        }
    }
}
