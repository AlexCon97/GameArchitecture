using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeLogic.Task_Manager {

    [CreateAssetMenu(menuName = "Game Managers/Task_Manager", fileName = "New Task_Manager")]
    public class TaskManager : BaseManager
    {
        [SerializeField] private bool UsingTaskTriggers;
        [SerializeField] private TaskTriggerBase[] TaskTriggers;
        [SerializeField] private TaskBase[] Tasks;

        private Dictionary<TaskTitle, TaskBase> TaskGroup = new Dictionary<TaskTitle, TaskBase>();
        private Dictionary<TaskTitle, TaskTriggerBase> TaskTriggersGroupOnScene = new Dictionary<TaskTitle, TaskTriggerBase>();
        
        private static TaskManager Instance;
        
        public static TaskBase CurrentTask { get; private set; }
        public static int TasksCompletedAmount { get; set; }

        #region Initialize
        public override void Initialize()
        {
            if (Instance != null) return;
            Instance = this;
            InitializeTasks();

            Debug.Log("TaskManager Initialized");
        }

        public static void ShowOrInitializeTaskTrigger(int initializeAmount = 1, bool forceInitialize = false)
        {
            if (forceInitialize && initializeAmount <= 0)
            {
                Debug.LogError("InitializeAmount must be more then 0");
                return;
            }

            if (!Instance.IsAnyTaskTriggerShowed() || forceInitialize)
            {
                InitializeTaskTriggers(initializeAmount);
            }
        }

        private static void InitializeTaskTriggers(int amount)
        {
            if (!Instance.UsingTaskTriggers) return;
            int tasksInitializedAmount = 0;
            for (int i = TasksCompletedAmount; i < Instance.TaskTriggers.Length; i++)
            {
                if (tasksInitializedAmount >= amount) return;
                var taskTrigger = Instantiate(Instance.TaskTriggers[i]);
                Instance.TaskTriggersGroupOnScene.Add(taskTrigger.GetTaskTitle, taskTrigger);
                taskTrigger.Initialize();
                tasksInitializedAmount++;
                Debug.Log("TaskTrigger Initialized");
            }
        }
        private static void InitializeTasks()
        {
            foreach (var taskItem in Instance.Tasks)
            {
                Instance.TaskGroup.Add(taskItem.GetTitle, taskItem);
            }
        }
        #endregion

        public static void CancelTask(TaskTitle title)
        {
            CurrentTask.CancelTask();
            UnhideAllTaskTriggers();
            Debug.Log("Task Canceled");
        }

        public void CompleteTask()
        {
            TasksCompletedAmount++;
            RemoveTaskTrigger(CurrentTask.GetTitle);
            UnhideAllTaskTriggers();
            Debug.Log("Task Completed");
        }

        public void ReloadTask(TaskTitle title)
        {
            CurrentTask.ReloadTask();
            Debug.Log("Task Reloaded");
        }

        public static void StartTask(TaskTitle title)
        {
            Debug.Log("Task Start");
            if (!Instance.TaskGroup.ContainsKey(title) || CurrentTask!=null)
            {
                Debug.LogError("Task Not Found or Started");
                return;
            }

            CurrentTask = Instance.TaskGroup[title];
            CurrentTask.OnTaskCompleted += Instance.CompleteTask;
            CurrentTask.InitializeTask();
            CurrentTask.StartTask();
            HideAllTaskTriggers();
            Debug.Log("Task Started Fully");
        }

        private bool IsAnyTaskTriggerShowed()
        {
            if (TaskTriggersGroupOnScene.Count <= 0) return false;

            UnhideAllTaskTriggers();

            return true;
        }
        private static void HideAllTaskTriggers()
        {
            foreach (var taskTriggerOnScene in Instance.TaskTriggersGroupOnScene)
            {
                taskTriggerOnScene.Value.HideMe();
            }
        }
        private static void UnhideAllTaskTriggers()
        {
            foreach (var taskTriggerOnScene in Instance.TaskTriggersGroupOnScene)
            {
                taskTriggerOnScene.Value.UnHideMe();
            }
        }
        private static void RemoveTaskTrigger(TaskTitle taskTitle)
        {
            var targetTaskTrigger = Instance.TaskTriggersGroupOnScene[taskTitle].gameObject;
            Instance.TaskTriggersGroupOnScene.Remove(taskTitle);
            CurrentTask = null;
        }
    }
}