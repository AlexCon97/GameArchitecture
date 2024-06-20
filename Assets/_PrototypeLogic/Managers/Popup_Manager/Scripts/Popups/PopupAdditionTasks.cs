using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrototypeLogic.Task_Manager;

namespace PrototypeLogic.Popup_Manager
{
    public class PopupAdditionTasks : PopupBase
    {
        [SerializeField] private PopupTaskRow additionTaskRowPrefab;
        [SerializeField] private Transform taskRowParent;

        private Dictionary<TaskTitle, PopupTaskRow> taskRowsGroup = new Dictionary<TaskTitle, PopupTaskRow>();

        public override void Initialize()
        {
            Debug.Log("PopupAdditionTasks Initialized");
        }

        public void AddRow(TaskTitle taskTitle)
        {
            var taskRaw = Instantiate(additionTaskRowPrefab);
            taskRaw.SetTaskIcon(TaskManager.GetUncompletedTaskIcon);
            taskRaw.SetTaskName(taskTitle.ToString());
            taskRaw.transform.SetParent(taskRowParent);
            taskRowsGroup.Add(taskTitle, taskRaw);
            PopupManager.ShowAndHidePopupWithTimer(PopupTitle.AdditionTaskInfo, new PopupShowImmediateBehavior());
        }

        public void CompleteTaskRow(TaskTitle taskTitle)
        {
            taskRowsGroup[taskTitle].SetTaskIcon(TaskManager.GetCompletedTaskIcon);
            PopupManager.ShowAndHidePopupWithTimer(PopupTitle.AdditionTaskInfo, new PopupShowImmediateBehavior());
        }

        public void RemoveAllRows()
        {
            foreach (var taskRow in taskRowsGroup)
            {
                Destroy(taskRow.Value.gameObject);
            }
            taskRowsGroup.Clear();
        }
    }
}