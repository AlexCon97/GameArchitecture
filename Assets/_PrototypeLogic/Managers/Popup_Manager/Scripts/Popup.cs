using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeLogic.Popup_Manager
{
    [System.Serializable]
    public class Popup
    {
        [SerializeField] private PopupTitle Title;
        [SerializeField] private PopupBase PopupPrefab;

        public PopupTitle GetTitle => Title;
        public PopupBase GetPopupPrefab => PopupPrefab;
    }
}