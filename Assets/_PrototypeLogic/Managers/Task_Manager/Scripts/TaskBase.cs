using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeLogic.Task_Manager
{
    public abstract class TaskBase : ScriptableObject
    {
        [SerializeField] private Sprite TaskSprite;
        [SerializeField] private string TaskShortName;
        [SerializeField] private string TaskFullName;

        [SerializeField] private TaskTitle Title;
        public TaskTitle GetTitle => Title;
        public bool IsTaskStarted { get; set; }

        public Sprite GetTaskSprite => TaskSprite;
        public string GetTaskShortName => TaskShortName;
        public string GetTaskFullName => TaskFullName;
        public Action OnTaskCanceled { get; set; }
        public Action<TaskTitle> OnTaskCompleted { get; set; }
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