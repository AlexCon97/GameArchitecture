using PrototypeLogic.Popup_Manager;
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
                TaskManager.CurrentTask = TaskManager.GetTask(GetTaskTitle);
                TaskManager.CurrentTask.OnTaskStarted += () => PopupManager.HidePopup(PopupTitle.ChapterTaskInfo, new PopupHideImmediateBehavior(), PopupHided);
                PopupManager.ShowAndHidePopupWithTimer(PopupTitle.ChapterTaskInfo, new PopupShowImmediateBehavior(), PopupShowed, 10);
            }
        }

        private void PopupShowed()
        {

            Debug.LogWarning("PopupManager.Showed(ChapterTask_Popup)");
        }
        private void PopupHided()
        {

            Debug.Log("PopupManager.Hided(ChapterTask_Popup)");
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<PlayerController>())
            {
                if (!TaskManager.CurrentTask.IsTaskStarted) TaskManager.CurrentTask = null;
                IsPlayerEnteredTrigger = false;
                //PopupManager.ShowAndHidePopupWithTimer(PopupTitle.AdditionTaskInfo, new PopupShowImmediateBehavior(), PopupShowed, 5);

            }
        }
    }
}