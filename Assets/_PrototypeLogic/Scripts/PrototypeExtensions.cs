using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using PrototypeLogic.Popup_Manager;
using System;

public static class PrototypeExtensions
{
    static private bool IsTimerBusy { get; set; }
    
    public static async void TimerToHide(this PopupBase popup, float timeToHide)
    {
        if (IsTimerBusy) return;
        IsTimerBusy = true;
        float currentTime = 0;
        while (currentTime < timeToHide)
        {
            Debug.Log("TIMER WORKS");
            currentTime += Time.deltaTime;
            await Task.Yield();
        }
        IsTimerBusy = false;
        popup.Hide();
    }

}
