using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PrototypeLogic.UI_Manager.Windows
{
    public class GamePauseWindow : BaseWindow
    {
        [SerializeField] private Button ContinueGameButton;
        [SerializeField] private Button SettingsButton;
        [SerializeField] private Button AboutButton;
        [SerializeField] private Button ExitButton;

        public override void Initialize()
        {
            ContinueGameButton.onClick.AddListener(ContinueGame);
            SettingsButton.onClick.AddListener(() => UIManager.Show(WindowTypes.Settings));
            AboutButton.onClick.AddListener(() => UIManager.Show(WindowTypes.AboutGame));
            ExitButton.onClick.AddListener(QuitGame);
        }

        private void ContinueGame()
        {
            UIManager.Close();
        }

        private void QuitGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(0);
        }
    }
}