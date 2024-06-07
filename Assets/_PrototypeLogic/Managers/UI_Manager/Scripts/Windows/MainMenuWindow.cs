using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PrototypeLogic.UI_Manager.Windows
{
    public class MainMenuWindow : BaseWindow
    {
        [SerializeField] private Button NewGameButton;
        [SerializeField] private Button SettingsButton;
        [SerializeField] private Button AboutButton;
        [SerializeField] private Button ExitButton;

        public override void Initialize()
        {
            NewGameButton.onClick.AddListener(Game_Manager.GameManager.Instance.StartNewGame);
            SettingsButton.onClick.AddListener(() => UIManager.Show(WindowTypes.Settings));
            AboutButton.onClick.AddListener(() => UIManager.Show(WindowTypes.AboutGame));
            ExitButton.onClick.AddListener(QuitGame);
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}