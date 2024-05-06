using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrototypeLogic.UI_Manager;
using UnityEngine.UI;

public class MainMenuWindow : BaseWindow
{
    [SerializeField] private Button UserButton;
    [SerializeField] private Button GuideButton;

    public override void Initialize()
    {
        UserButton.onClick.AddListener(() => UIManager.Instance.Show(WindowTypes.SelectLevel));
        GuideButton.onClick.AddListener(() => UIManager.Instance.Show(WindowTypes.Guide));
    }
}
