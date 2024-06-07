using System;
using UnityEngine;
using PrototypeLogic.Game_Manager;

namespace PrototypeLogic.Task_Manager
{
    public class TaskTriggerBase : MonoBehaviour, IUpdateble 
    {
        [SerializeField] private TaskTitle TaskTitleName;
        private Collider triggerCollider;
        protected bool IsPlayerEnteredTrigger;
        
        public bool NeedHideMesh;
        public Action OnTriggerEntered;
        public Action OnTriggerExited;

        public TaskTitle GetTaskTitle => TaskTitleName;

        public void Initialize()
        {
            GameManager.Instance.AddUpdatableItem(this);
            triggerCollider = GetComponent<Collider>();
            //OnTriggerEntered+=PopupManager
        }

        public void MyUpdate()
        {
            if (!IsPlayerEnteredTrigger) return;
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                TaskManager.StartTask(TaskTitleName);
                IsPlayerEnteredTrigger = false;
                //HideMe();
            }
        }

        public void UnHideMe()
        {
            if (NeedHideMesh)
            {
                gameObject.SetActive(true);
            }
            else
            {
                triggerCollider.enabled = true;
            }
        }

        public void HideMe()
        {
            if (NeedHideMesh)
            {
                gameObject.SetActive(false);
            }
            else
            {
                triggerCollider.enabled = false;
            }
        }

        private void OnDestroy()
        {
            GameManager.Instance.RemoveUpdatableItem(this);
        }
    }
}