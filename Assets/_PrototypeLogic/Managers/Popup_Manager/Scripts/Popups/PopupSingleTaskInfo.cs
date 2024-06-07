using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeLogic.Popup_Manager
{
    public class PopupSingleTaskInfo : PopupBase
    {
        private void Awake()
        {
            SetShowBehavior(new PopupShowAnimBehavior());
        }
    }
}