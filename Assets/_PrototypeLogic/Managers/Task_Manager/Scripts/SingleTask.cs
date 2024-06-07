using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeLogic.Task_Manager
{
    public class SingleTask : TaskBase
    {
        private bool IsStarted { get; set; }

        public override void CancelTask()
        {
            Debug.Log("SingleTask Parent Cancele");
            OnTaskCanceled?.Invoke();
        }

        public override void CompleteTask()
        {
            Debug.Log("SingleTask Parent Complete");
            OnTaskCompleted?.Invoke();
        }

        public override void InitializeTask()
        {
            ResetValues();
            Debug.Log("SingleTask Parent Initialize");
            OnTaskInitialized?.Invoke();
        }

        public override void ReloadTask()
        {
            if (!IsStarted) return;
            Debug.Log("SingleTask Parent Reload");
            OnTaskReloaded?.Invoke();
        }

        public override void ResetValues()
        {
            
        }

        public override void StartTask()
        {
            IsStarted = true;
            Debug.Log("SingleTask Parent Start");
            OnTaskStarted?.Invoke();
        }
    }
}