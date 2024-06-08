using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeLogic.Task_Manager
{
    [CreateAssetMenu(menuName = "Task_Manager/SingleTasks/CollectItems", fileName = "SingleTask_CollectItems")]
    public class SingleTask_CollectItems : SingleTask
    {
        [SerializeField] private CoinTrigger coinPrefab;
        [SerializeField] private Vector3[] locations;

        private List<CoinTrigger> spawnedCoins;
        private int collectedCoinsAmount;
        private int coinsAmount;

        public override void ResetValues()
        {
            base.ResetValues();
            Debug.Log("Reset");
            collectedCoinsAmount = 0;
            coinsAmount = locations.Length;
        }

        public override void InitializeTask()
        {
            base.InitializeTask();
            spawnedCoins = new List<CoinTrigger>();

            for (int i = 0; i < coinsAmount; i++)
            {
                var coin = Instantiate(coinPrefab, locations[i], Quaternion.identity);
                coin.OnCoinCollected += CoinCollect;
                coin.HideMe();
                spawnedCoins.Add(coin);
            }
            Debug.Log(spawnedCoins.Count + " Spawned Coins amount INIT");
            Debug.Log("SingleTask Concrete Initialize");
        }

        private void CoinCollect()
        {
            collectedCoinsAmount++;
            Debug.LogWarning(collectedCoinsAmount);
            if(collectedCoinsAmount >= coinsAmount)
            {
                CompleteTask();
            }
        }

        public override void StartTask()
        {
            base.StartTask();
            for (int i = 0; i < locations.Length; i++)
            {
                spawnedCoins[i].UnhideMe();
            }
            Debug.Log(spawnedCoins.Count + " Spawned Coins amount START");
            Debug.Log("SingleTask Concrete Start");
        }

        public override void CompleteTask()
        {
            base.CompleteTask();
            Debug.Log("Single Task Completed");
        }

        public override void CancelTask()
        {
            base.CancelTask();

            Debug.Log(spawnedCoins.Count + " Spawned Coins amount CANCEL");
            for (int i = 0; i < spawnedCoins.Count; i++)
            {
                Destroy(spawnedCoins[i].gameObject);
            }
            spawnedCoins.Clear();
        }

        public override void ReloadTask()
        {
            base.ReloadTask();
            for (int i = 0; i < spawnedCoins.Count; i++)
            {
                spawnedCoins[i].HideMe();
            }
            Debug.Log("Concrete Reloaded");
        }
    }
}