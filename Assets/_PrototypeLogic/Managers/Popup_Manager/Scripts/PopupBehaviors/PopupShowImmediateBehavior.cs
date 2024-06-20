using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace PrototypeLogic.Popup_Manager
{
    public class PopupShowImmediateBehavior : IPopupShowBehavior
    {
        //private bool IsBusy { get; set; }
        public async Task Show(PopupBase popup)
        {
            //if (IsBusy) return;
            //IsBusy = true;
            //for (int i = 0; i < 1000; i++)
            //{
            //    Debug.Log("_");
            //    await Task.Yield();
            //}
            popup.gameObject.SetActive(true);
            //IsBusy = false;
            //Debug.Log("SHOWWW");
        }
    }
}