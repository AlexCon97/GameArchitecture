using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace PrototypeLogic.Popup_Manager
{
    public class PopupShowAnimBehavior : IPopupShowBehavior
    {
        public void Show()
        {
            Debug.Log("Start");
            Task.Delay(1000);
            Debug.Log("End");
        }
    }
}