using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrototypeLogic.UI_Manager;
using UnityEngine.UI;

public class GuideWindow : BaseWindow
{
    [SerializeField] private Button NextButton;
    public override void Initialize()
    {
        NextButton.onClick.AddListener(() => UIManager.Instance.Back());
    }
}
