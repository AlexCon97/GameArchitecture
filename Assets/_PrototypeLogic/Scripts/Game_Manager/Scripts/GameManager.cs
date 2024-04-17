using System;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeLogic.Game_Manager
{
    public class GameManager : MonoBehaviour
    {
		#region ForDebug
		public int GetUpdatableCount => UpdatableGroup.Count;
		public int GetLateUpdatableCount => LateUpdatableGroup.Count;

		public void GetUpdatableTypes()
		{
			for(int i=0; i < GetUpdatableCount; i++)
			{
				Debug.Log(UpdatableGroup[i].GetType());
			}
		}
		public void GetLateUpdatableTypes()
		{
			for(int i=0; i < GetUpdatableCount; i++)
			{
				Debug.Log(LateUpdatableGroup[i].GetType());
			}
		}
		#endregion

		[SerializeField] private List<BaseManager> BaseManagersGroup = new List<BaseManager>();
        
        private List<IUpdateble> UpdatableGroup;
        private List<ILateUpdateble> LateUpdatableGroup;
		
		public void AddUpdatableItem(IUpdateble item) => UpdatableGroup.Add(item);
		public void RemoveUpdatableItem(IUpdateble item) => UpdatableGroup.Remove(item);
        public void AddLateUpdatableItem(ILateUpdateble item) => LateUpdatableGroup.Add(item);
        public void RemoveLateUpdatableItem(ILateUpdateble item) => LateUpdatableGroup.Remove(item);
		
		public static GameManager Instance;

		private void Awake()
        {
			if (Instance != null) return;
			Instance = this;
			DontDestroyOnLoad(this);

			UpdatableGroup = new List<IUpdateble>();
			LateUpdatableGroup = new List<ILateUpdateble>();

			foreach (var baseManager in BaseManagersGroup)
			{
				baseManager.Initialize();
			}
		}

        private void Update()
        {
			if (UpdatableGroup.Count == 0) return;

			foreach (var updatebleItem in UpdatableGroup)
            {
                updatebleItem.MyUpdate();
            }
        }

        private void LateUpdate()
        {
			if (LateUpdatableGroup.Count == 0) return;

			foreach (var lateUdatebleItem in LateUpdatableGroup)
            {
                lateUdatebleItem.MyLateUpdate();
			}
		}

		public void StartGame()
        {
            Debug.Log("Game Started");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}