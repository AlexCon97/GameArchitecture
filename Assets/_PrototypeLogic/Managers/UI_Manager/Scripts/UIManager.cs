using System;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeLogic.UI_Manager
{
    public class UIManager : BaseManager
    {
        [SerializeField] private List<UIWindow> WindowsList;
    
        private BaseWindow CurrentWindow;
        private Stack<BaseWindow> WindowsStack = new Stack<BaseWindow>();
        private Dictionary<WindowTypes, BaseWindow> WindowsDictionary = new Dictionary<WindowTypes, BaseWindow>();

        public static UIManager Instance;

        public override void Initialize()
        {
			if (Instance != null) return;
			Instance = this;

            foreach (var window in WindowsList)
            {
                WindowsDictionary.Add(window.type, window.prefab);
            }
        }
    
        public void Show(WindowTypes windowType)
        {
            if (CurrentWindow != null) CurrentWindow.DestroyWindow();
            CurrentWindow = WindowsDictionary[windowType].CreateWindow();
            CurrentWindow.Initialize();
            WindowsStack.Push(WindowsDictionary[windowType]);
        }
    
        public void Close()
        {
            CurrentWindow.DestroyWindow();
            WindowsStack.Clear();
        }
    
        public void Back()
        {
            if (WindowsStack.Count <= 1) return;
            CurrentWindow.DestroyWindow();
            WindowsStack.Pop();
            CurrentWindow = WindowsStack.Peek().CreateWindow();
            CurrentWindow.Initialize();
		}
    
        [Serializable]
        private struct UIWindow
        {
            public WindowTypes type;
            public BaseWindow prefab;
        }
    }
}