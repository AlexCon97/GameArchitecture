using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrototypeLogic.Popup_Manager;

namespace PrototypeLogic.Task_Manager
{
    [CreateAssetMenu(menuName = "Task_Manager/ChapterTasks/Collectable", fileName = "ChapterTask_Collectable")]
    public class ChapterTask_Collectable : ChapterTask
    {

        public override void InitializeTask()
        {
            base.InitializeTask();
            Debug.Log("DDDDDd");
            OnAdditionTaskStarted = OnAdditionTaskStartedFunc;
            OnAdditionTaskCompleted = OnAdditionTaskCompletedFunc;
        }

        private void OnAdditionTaskStartedFunc(TaskTitle taskTitle)
        {
            Debug.Log("ADDDs");
            var additionTasksPopup = (PopupAdditionTasks)PopupManager.GetInitializedPopups[PopupTitle.AdditionTaskInfo];
            additionTasksPopup.AddRow(taskTitle);
            //PopupManager.ShowAndHidePopupWithTimer(PopupTitle.AdditionTaskInfo, new PopupShowImmediateBehavior());
        }private void OnAdditionTaskCompletedFunc(TaskTitle taskTitle)
        {
            Debug.Log("ADDDs");
            var additionTasksPopup = (PopupAdditionTasks)PopupManager.GetInitializedPopups[PopupTitle.AdditionTaskInfo];
            additionTasksPopup.CompleteTaskRow(taskTitle);
            //PopupManager.ShowAndHidePopupWithTimer(PopupTitle.AdditionTaskInfo, new PopupShowImmediateBehavior());
        }

        public override void StartTask()
        {
            base.StartTask();
            AdditionTaskStart();
            AdditionTaskStart();
            Debug.Log("ChapterTask Concrete Start");
        }

        public override void CompleteAllAdditionTasks()
        {
            //throw new System.NotImplementedException();
        }


    }
}