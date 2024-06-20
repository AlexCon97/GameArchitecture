using System;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeLogic.Game_Manager
{
    public class GameManager : MonoBehaviour
    {
		#region ForDebug
		public int GetUpdatableCount => Instance.UpdatableGroup.Count;
		public int GetLateUpdatableCount => Instance.LateUpdatableGroup.Count;

		public void GetUpdatableTypes()
		{
			for(int i=0; i < Instance.GetUpdatableCount; i++)
			{
				Debug.Log(Instance.UpdatableGroup[i].GetType());
			}
		}
		public void GetLateUpdatableTypes()
		{
			for(int i=0; i < Instance.GetUpdatableCount; i++)
			{
				Debug.Log(Instance.LateUpdatableGroup[i].GetType());
			}
		}
		#endregion

		[SerializeField] private List<BaseManager> BaseManagersGroup = new List<BaseManager>();
		[SerializeField] private HUD Hud;

        private List<IUpdateble> UpdatableGroup;
        private List<ILateUpdateble> LateUpdatableGroup;
		
		public void AddUpdatableItem(IUpdateble item) => Instance.UpdatableGroup.Add(item);
		public void RemoveUpdatableItem(IUpdateble item) => Instance.UpdatableGroup.Remove(item);
        public void AddLateUpdatableItem(ILateUpdateble item) => Instance.LateUpdatableGroup.Add(item);
        public void RemoveLateUpdatableItem(ILateUpdateble item) => Instance.LateUpdatableGroup.Remove(item);
		
		public static GameManager Instance;

		private void Awake()
        {
			if (Instance != null) return;
			Instance = this;
			
			var hud = Instantiate(Instance.Hud);
			hud.Initialize();

			Instance.UpdatableGroup = new List<IUpdateble>();
			Instance.LateUpdatableGroup = new List<ILateUpdateble>();

			foreach (var baseManager in Instance.BaseManagersGroup)
			{
				baseManager.Initialize();
			}
			

			DontDestroyOnLoad(this);
		}

        private void Update()
        {
			if (Instance.UpdatableGroup.Count == 0) return;

			foreach (var updatebleItem in Instance.UpdatableGroup)
            {
                updatebleItem.MyUpdate();
            }
        }

        private void LateUpdate()
        {
			if (Instance.LateUpdatableGroup.Count == 0) return;

			foreach (var lateUdatebleItem in Instance.LateUpdatableGroup)
            {
                lateUdatebleItem.MyLateUpdate();
			}
		}

		public void StartNewGame()
        {
			UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1);
			Debug.Log("Game Started");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}