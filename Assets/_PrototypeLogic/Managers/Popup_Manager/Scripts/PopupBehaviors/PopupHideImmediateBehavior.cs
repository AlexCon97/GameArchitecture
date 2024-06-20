using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace PrototypeLogic.Popup_Manager
{
    public class PopupHideImmediateBehavior : IPopupHideBehavior
    {
        //private bool IsBusy { get; set; }
        public async Task Hide(PopupBase popup)
        {
            //if (IsBusy) return;
            //IsBusy = true;
            //for (int i = 0; i < 1000; i++)
            //{
            //    Debug.Log("_");
            //    await Task.Yield();
            //}
            popup.gameObject.SetActive(false);
            //IsBusy = false;
            //Debug.Log("HIDEEE");
        }
    }
}