using System;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeLogic.UI_Manager
{
    [CreateAssetMenu(menuName = "Game Managers/UI_Manager", fileName = "New UI_Manager")]
    public class UIManager : BaseManager
    {
        [SerializeField] private List<UIWindow> WindowsList;
    
        private BaseWindow CurrentWindow;
        private Stack<BaseWindow> WindowsStack = new Stack<BaseWindow>();
        private Dictionary<WindowTypes, BaseWindow> WindowsDictionary = new Dictionary<WindowTypes, BaseWindow>();

        private static UIManager Instance;

        public override void Initialize()
        {
			if (Instance != null) return;
			Instance = this;

            foreach (var window in WindowsList)
            {
                Instance.WindowsDictionary.Add(window.type, window.prefab);
            }

            Debug.Log("UIManager Initialized");
        }
    
        public static void Show(WindowTypes windowType)
        {
            if (Instance.CurrentWindow != null) Instance.CurrentWindow.DestroyWindow();
            Instance.CurrentWindow = Instance.WindowsDictionary[windowType].CreateWindow();
            Instance.CurrentWindow.Initialize();
            Instance.WindowsStack.Push(Instance.WindowsDictionary[windowType]);
        }
    
        public static void Close()
        {
            Instance.CurrentWindow.DestroyWindow();
            Instance.WindowsStack.Clear();
        }
    
        public static void Back()
        {
            if (Instance.WindowsStack.Count <= 1) return;
            Instance.CurrentWindow.DestroyWindow();
            Instance.WindowsStack.Pop();
            Instance.CurrentWindow = Instance.WindowsStack.Peek().CreateWindow();
            Instance.CurrentWindow.Initialize();
		}
    
        [Serializable]
        private struct UIWindow
        {
            public WindowTypes type;
            public BaseWindow prefab;
        }
    }
}