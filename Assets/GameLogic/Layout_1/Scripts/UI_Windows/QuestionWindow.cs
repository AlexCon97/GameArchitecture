using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrototypeLogic.UI_Manager;
using UnityEngine.UI;

public class QuestionWindow : BaseWindow
{
    [SerializeField] private Button PencilButton;
    [SerializeField] private Button BackButton;

    public override void Initialize()
    {
        PencilButton.onClick.AddListener(() => UIManager.Instance.Show(WindowTypes.Success));
        BackButton.onClick.AddListener(() => UIManager.Instance.Back());
    }
}
