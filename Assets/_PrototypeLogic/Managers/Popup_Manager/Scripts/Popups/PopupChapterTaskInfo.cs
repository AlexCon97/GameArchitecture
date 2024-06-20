using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using PrototypeLogic.Task_Manager;

namespace PrototypeLogic.Popup_Manager
{
    public class PopupChapterTaskInfo : PopupBase
    {
        [SerializeField] private TextMeshProUGUI ChapterShortName;
        [SerializeField] private Image ChapterIcon;
        [SerializeField] private TextMeshProUGUI ChapterFullName;

        public override void Initialize()
        {   
            
        }

        public override void SetInfo()
        {
            var currentTask = (ChapterTask)TaskManager.CurrentTask;
            ChapterShortName.text = currentTask.GetTaskShortName;
            ChapterFullName.text = currentTask.GetTaskFullName;
            ChapterIcon.sprite = currentTask.GetTaskSprite ? currentTask.GetTaskSprite : TaskManager.GetDefaultTaskIcon;
        }
    }
}