using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeLogic.Popup_Manager
{
    public class PopupChapterTaskInfo : PopupBase
    {
        private void Awake()
        {
            SetShowBehavior(new PopupShowAnimBehavior());
        }
    }
}