using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeLogic.Task_Manager
{
    [CreateAssetMenu(menuName = "Task_Manager/ChapterTasks/Collectable", fileName = "ChapterTask_Collectable")]
    public class ChapterTask_Collectable : ChapterTask
    {
        

        public override void StartTask()
        {
            base.StartTask();
            Debug.Log("ChapterTask Concrete Start");
        }

        public override void CompleteAllAdditionTasks()
        {
            //throw new System.NotImplementedException();
        }


    }
}