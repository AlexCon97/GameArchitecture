// Addition tasks spawn to popup. Check and mark spawned addition tasks
// CompleteTask popup

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using PrototypeLogic.Game_Manager;
using System;

namespace PrototypeLogic.Popup_Manager 
{
    [CreateAssetMenu(menuName = "Game Managers/Popup_Manager", fileName = "New PopupManager")]
    public class PopupManager : BaseManager
    {
        [SerializeField] private Popup[] Popups;

        //private Dictionary<PopupTitle, PopupBase> popupPrefabsGroup = new Dictionary<PopupTitle, PopupBase>();
        private Dictionary<PopupTitle, PopupBase> initializedPopups = new Dictionary<PopupTitle, PopupBase>();
        private static PopupManager Instance;

        public static Dictionary<PopupTitle, PopupBase> GetInitializedPopups => Instance.initializedPopups;
        public override void Initialize()
        {
            if (Instance != null) return;
            Instance = this;

            foreach (var popup in Instance.Popups)
            {
                var popupBase = Instantiate(popup.GetPopupPrefab);
                popupBase.Initialize();
                popupBase.gameObject.SetActive(false);

                switch (popup.GetTitle)
                {
                    case PopupTitle.None:
                        break;
                    case PopupTitle.ChapterTaskInfo:
                        popupBase.transform.SetParent(HUD.GetChapterTaskInfoParent);
                        break;
                    case PopupTitle.AdditionTaskInfo:
                        popupBase.transform.SetParent(HUD.GetAdditionTaskInfoParent);
                        break;
                    case PopupTitle.MainTaskInfo:
                        popupBase.transform.SetParent(HUD.GetMainInfoParent);
                        break;
                    case PopupTitle.GameInfo:
                        popupBase.transform.SetParent(HUD.GetGameInfoParent);
                        break;
                    default:
                        break;
                }
                popupBase.SetShowBehavior(new PopupShowImmediateBehavior());
                popupBase.SetHideBehavior(new PopupHideImmediateBehavior());
                
                Instance.initializedPopups.Add(popup.GetTitle, popupBase);
            }

            Debug.Log("Popup Manager Initialized");
        }

        //public static PopupBase InitializePopup(PopupTitle title, Transform parent, IPopupShowBehavior showBehavior)
        //{
        //    var popup = Instantiate(Instance.popupPrefabsGroup[title]);
        //    popup.gameObject.SetActive(false);
        //    popup.Initialize();
        //    popup.SetShowBehavior(showBehavior);
        //    popup.transform.SetParent(parent);
        //    Instance.initializedPopups.Add(title, popup);
        //    return popup;
        //}
        //public static void RemovePopup(PopupTitle title)
        //{
        //    if (!Instance.initializedPopups.ContainsKey(title)) return;
        //    Destroy(Instance.initializedPopups[title].gameObject);
        //    Instance.initializedPopups.Remove(title);
        //}



        public static void HidePopup(PopupTitle title, IPopupHideBehavior hideBehavior, Action popupHidedAction)
        {
            Instance.initializedPopups[title].OnPopupHided = popupHidedAction;
            Instance.initializedPopups[title].SetHideBehavior(hideBehavior);
            Instance.initializedPopups[title].Hide();
        }
        public static void ShowPopup(PopupTitle title, IPopupShowBehavior showBehavior, Action popupShowedAction)
        {
            Instance.initializedPopups[title].OnPopupShowed = popupShowedAction;
            Instance.initializedPopups[title].SetShowBehavior(showBehavior);
            Instance.initializedPopups[title].Show();
        }
        public static void ShowAndHidePopupWithTimer(PopupTitle title, IPopupShowBehavior showBehavior, Action popupShowedAction = null, float timeToHideSec = 3)
        {
            Instance.initializedPopups[title].OnPopupShowed = popupShowedAction;
            Instance.initializedPopups[title].SetInfo();
            Instance.initializedPopups[title].SetShowBehavior(showBehavior);
            Instance.initializedPopups[title].ShowWithTimer(timeToHideSec);
        }
    }
}