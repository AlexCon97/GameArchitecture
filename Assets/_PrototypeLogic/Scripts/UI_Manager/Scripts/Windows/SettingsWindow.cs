using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PrototypeLogic.UI_Manager.Windows
{
    public class SettingsWindow : BaseWindow
    {
        [SerializeField] private Button BackButton;

        public override void Initialize()
        {
            BackButton.onClick.AddListener(UIManager.Instance.Back);
        }
    }
}