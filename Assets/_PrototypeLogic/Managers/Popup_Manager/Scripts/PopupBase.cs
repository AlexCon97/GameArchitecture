using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace PrototypeLogic.Popup_Manager
{
    public abstract class PopupBase : MonoBehaviour
    {
        private IPopupShowBehavior ShowBehavior;
        private IPopupHideBehavior HideBehavior;

        public Action OnPopupShowed;
        public Action OnPopupHided;

        public bool isBusy { get; set; }

        public abstract void Initialize();
        public virtual void SetInfo() { }

        public void SetShowBehavior(IPopupShowBehavior showBehavior)
        {
            ShowBehavior = showBehavior;
        }
        public void SetHideBehavior(IPopupHideBehavior hideBehavior)
        {
            HideBehavior = hideBehavior;
        }

        /// <summary>
        /// timeToHide = seconds amount to hide popup
        /// </summary>
        /// <param name="timeToHideSec"></param>
        public async void Show()
        {
            if (isBusy) return;
            isBusy = true;
            await ShowBehavior.Show(this);
            OnPopupShowed?.Invoke();
            Debug.Log("Showed");
            isBusy = false;
        }
        public async void ShowWithTimer(float timeToHideSec = 0)
        {
            float currentTime = 0;
            Debug.LogWarning("TIMER WORKS: " + currentTime);
            if (isBusy) return;
            isBusy = true;
            await ShowBehavior.Show(this);
            OnPopupShowed?.Invoke();
            Debug.Log("Showed");

            if (timeToHideSec < 0) timeToHideSec = 0;
            while (currentTime < timeToHideSec)
            {
                currentTime += Time.deltaTime;
                await Task.Yield();
            }
            await HideBehavior.Hide(this);
            OnPopupHided?.Invoke();
            isBusy = false;
        }
        public async void Hide()
        {
            if (isBusy) return;
            isBusy = true;
            await HideBehavior.Hide(this);
            OnPopupHided?.Invoke();
            isBusy = false;
            Debug.Log("Hided");
        }
    }
}