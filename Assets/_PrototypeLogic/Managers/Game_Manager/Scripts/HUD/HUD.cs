using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PrototypeLogic.Game_Manager
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private GameCurrency Currency;
        [SerializeField] private Transform PlayerInfoParent;
        [SerializeField] private Transform MainTaskInfoParent;
        [SerializeField] private Transform ChapterTaskInfoParent;
        [SerializeField] private Transform GameMapParent;
        [SerializeField] private TextMeshProUGUI ResourcesText;
        [SerializeField] private Transform GameInfoParent;
        [SerializeField] private Transform AdditionTaskInfoParent;
        [SerializeField] private Transform PlayerArtefactsInfoParent;

        private static HUD Instance;

        public static Transform GetChapterTaskInfoParent => Instance.ChapterTaskInfoParent;
        public static Transform GetMainInfoParent => Instance.MainTaskInfoParent;
        public static Transform GetAdditionTaskInfoParent => Instance.AdditionTaskInfoParent;
        public static Transform GetGameInfoParent => Instance.GameInfoParent;

        public void Initialize()
        {
            if (Instance != null) return;
            Instance = this;
            InActive();
            DontDestroyOnLoad(gameObject);
        }

        public static void Active()
        {
            Instance.gameObject.SetActive(true);
        }
        public static void InActive()
        {
            Instance.gameObject.SetActive(false);
        }
        
    }
}