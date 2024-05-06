using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrototypeLogic.UI_Manager;
using UnityEngine.UI;

public class SuccessWindow : BaseWindow
{
    [SerializeField] private Button CancelButton;
    [SerializeField] private Button NextStageButton;
    [SerializeField] private Button PlayAgainButton;

    public override void Initialize()
    {
        CancelButton.onClick.AddListener(CancelGame);
        NextStageButton.onClick.AddListener(CancelGame);
        PlayAgainButton.onClick.AddListener(CancelGame);
    }

    private void CancelGame()
    {
        UIManager.Instance.Close();
        UIManager.Instance.Show(WindowTypes.MainMenu);
    }
}
