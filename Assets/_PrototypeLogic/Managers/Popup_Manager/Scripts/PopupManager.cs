using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeLogic.Popup_Manager {

    [CreateAssetMenu(menuName = "Game Managers/Popup_Manager", fileName = "New PopupManager")]
    public class PopupManager : BaseManager
    {
        [SerializeField] private Popup[] Popups;

        private Dictionary<PopupTitle, PopupBase> popupPrefabsGroup = new Dictionary<PopupTitle, PopupBase>();
        private Dictionary<PopupTitle, PopupBase> initializedPopups = new Dictionary<PopupTitle, PopupBase>();
        private static PopupManager Instance;

        public override void Initialize()
        {
            if (Instance != null) return;
            Instance = this;

            foreach (var popup in Instance.Popups)
            {
                Instance.popupPrefabsGroup.Add(popup.GetTitle, popup.GetPopupPrefab);
            }

            Debug.Log("Popup Manager Initialized");
        }

        public static void InitializePopup(PopupTitle title, IPopupShowBehavior showBehavior)
        {
            var popup = Instantiate(Instance.popupPrefabsGroup[title]);
            popup.SetShowBehavior(showBehavior);
            Instance.initializedPopups.Add(title, popup);
        }
        public static void RemovePopup(PopupTitle title)
        {
            var popup = Instance.popupPrefabsGroup[title];
            Destroy(popup);
            Instance.popupPrefabsGroup.Remove(title);
        }
    }
}