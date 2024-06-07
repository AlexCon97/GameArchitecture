using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeLogic.Task_Manager
{
    public abstract class ChapterTask : TaskBase
    {
        [SerializeField] private Sprite ChapterSprite;
        [SerializeField] private string ChapterNumber;
        [SerializeField] private string ChapterName;
        [SerializeField] private string ChapterDescription;
        [SerializeField] private SingleTask[] SingleTasks;
        [SerializeField] private SingleTask[] AdditionTasks;

        private List<SingleTask> SingleTaskGroupOnScene;
        private List<SingleTask> AdditionTaskGroupOnScene;

        private int SingleTaskIndex { get; set; }
        private int AdditionTaskIndex { get; set; }
        private int AdditionTaskCompletedAmount { get; set; }
        private int SingleTaskCompletedAmount { get; set; }

        public Action OnAdditionTasksCompleted { get; set; }

        public Sprite GetChapterSprite => ChapterSprite;
        public string GetChapterNumber => ChapterNumber;
        public string GetChapterName => ChapterName;
        public string GetChapterDescription => ChapterDescription;

        public virtual void CompleteAllAdditionTasks()
        {
            Debug.Log("ChapterTask Parent Complete Addition Tasks");
            OnAdditionTasksCompleted?.Invoke();
        }

        public override void CancelTask()
        {
            Debug.Log("ChapterTask Parent Cancel");
            foreach (var singleTask in SingleTasks)
            {
                singleTask.CancelTask();
            }

            foreach (var additionTask in AdditionTasks)
            {
                additionTask.CancelTask();
            }
            OnTaskCanceled?.Invoke();
        }

        public override void CompleteTask()
        {
            Debug.Log("ChapterTask Parent Complete");
            OnTaskCompleted?.Invoke();
        }

        public override void ResetValues()
        {
            SingleTaskGroupOnScene = new List<SingleTask>();
            AdditionTaskGroupOnScene = new List<SingleTask>();
            OnAdditionTasksCompleted = null;
            SingleTaskIndex = 0;
            AdditionTaskIndex = 0;
            AdditionTaskCompletedAmount = 0;
            SingleTaskCompletedAmount = 0;
        }

        public override void InitializeTask()
        {
            Debug.Log("ChapterTask Parent Initialize");

            ResetValues();
            foreach (var singleTaskPrefab in SingleTasks)
            {
                var singleTask = Instantiate(singleTaskPrefab);
                singleTask.InitializeTask();
                singleTask.OnTaskCompleted += SingleTaskComplete;
                SingleTaskGroupOnScene.Add(singleTask);
            }
            
            foreach (var additionTaskPrefab in AdditionTasks)
            {
                var additionTask = Instantiate(additionTaskPrefab);
                additionTask.InitializeTask();
                additionTask.OnTaskCompleted += AdditionTaskComplete;
                AdditionTaskGroupOnScene.Add(additionTask);
            }
            OnTaskInitialized?.Invoke();
        }

        public override void ReloadTask()
        {
            OnTaskReloaded?.Invoke();
            ResetValues();
            Debug.Log("ChapterTask Parent Reload");
            foreach (var singleTask in SingleTasks)
            {
                singleTask.ReloadTask();
            }

            foreach (var additionTask in AdditionTasks)
            {
                additionTask.ReloadTask();
            }
        }

        public override void StartTask()
        {
            Debug.Log("ChapterTask Parent Start");
            SingleTaskStart();
            OnTaskStarted?.Invoke();
        }

        protected void SingleTaskStart()
        {
            if (SingleTaskIndex >= SingleTasks.Length) return;
            SingleTaskGroupOnScene[SingleTaskIndex].StartTask();
            SingleTaskIndex++;
        }
        protected void AdditionTaskStart()
        {
            if (AdditionTaskIndex >= AdditionTasks.Length) return;
            AdditionTaskGroupOnScene[AdditionTaskIndex].StartTask();
            AdditionTaskIndex++;
        }

        private void SingleTaskComplete()
        {
            SingleTaskCompletedAmount++;
            Debug.Log(SingleTaskCompletedAmount+"=="+ SingleTasks.Length);
            if (SingleTaskCompletedAmount == SingleTasks.Length)
            {
                Debug.Log("ChapterTask Parent Completed");
                CompleteTask();
            }
            SingleTaskStart();
        }
        private void AdditionTaskComplete()
        {
            AdditionTaskCompletedAmount++;
            if (AdditionTaskCompletedAmount == AdditionTasks.Length)
            {
                Debug.Log("ChapterTask Parent AdditionTask Complete and Reward");
                CompleteAllAdditionTasks();
            }
            
        }

    }
}