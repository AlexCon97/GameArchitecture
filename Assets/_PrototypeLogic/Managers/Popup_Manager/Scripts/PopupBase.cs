using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace PrototypeLogic.Popup_Manager
{
    public class PopupBase : MonoBehaviour
    {
        private IPopupShowBehavior ShowBehavior;
        private IPopupHideBehavior HideBehavior;

        public void SetShowBehavior(IPopupShowBehavior showBehavior)
        {
            ShowBehavior = showBehavior;
        }
        public void SetHideBehavior(IPopupHideBehavior hideBehavior)
        {
            HideBehavior = hideBehavior;
        }

        public async void Show()
        {
            await Task.Run(() => ShowBehavior.Show());
            Debug.Log("Showed");
        }
        public void Hide()
        {
            HideBehavior.Hide();
        }
    }
}