using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeLogic.Task_Manager
{
    public abstract class TaskBase : ScriptableObject
    {
        [SerializeField] private TaskTitle Title;
        public TaskTitle GetTitle => Title;

        public Action OnTaskCanceled { get; set; }
        public Action OnTaskCompleted { get; set; }
        public Action OnTaskInitialized { get; set; }
        public Action OnTaskReloaded { get; set; }
        public Action OnTaskStarted { get; set; }

        public abstract void CancelTask();
        public abstract void CompleteTask();
        public abstract void InitializeTask();
        public abstract void ReloadTask();
        public abstract void ResetValues();
        public abstract void StartTask();
    }
}