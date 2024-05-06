using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrototypeLogic.UI_Manager;
using UnityEngine.UI;

public class SelectLevelWindow : BaseWindow
{
    [SerializeField] private Button BackButton;
    [SerializeField] private Button FirstLevelButton;

    public override void Initialize()
    {
        FirstLevelButton.onClick.AddListener(() => UIManager.Instance.Show(WindowTypes.Question));
        BackButton.onClick.AddListener(() => UIManager.Instance.Back());
    }
}
