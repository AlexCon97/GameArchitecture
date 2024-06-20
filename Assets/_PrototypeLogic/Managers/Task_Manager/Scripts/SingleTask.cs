using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeLogic.Task_Manager
{
    public abstract class SingleTask : TaskBase
    {
        public override void CancelTask()
        {
            Debug.Log("SingleTask Parent Canceled");
            OnTaskCanceled?.Invoke();
        }

        public override void CompleteTask()
        {
            Debug.Log("SingleTask Parent Complete");
            OnTaskCompleted?.Invoke(GetTitle);
        }

        public override void InitializeTask()
        {
            ResetValues();
            Debug.Log("SingleTask Parent Initialize");
            OnTaskInitialized?.Invoke();
        }

        public override void ReloadTask()
        {
            ResetValues();
            Debug.Log("SingleTask Parent Reload");
            OnTaskReloaded?.Invoke();
        }

        public override void ResetValues()
        {
            
        }

        public override void StartTask()
        {
            Debug.Log("SingleTask Parent Start");
            OnTaskStarted?.Invoke();
        }
    }
}