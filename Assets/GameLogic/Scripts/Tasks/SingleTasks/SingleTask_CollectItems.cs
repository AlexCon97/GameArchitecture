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

            spawnedCoins = new List<CoinTrigger>();
            collectedCoinsAmount = 0;
            coinsAmount = locations.Length;
        }

        public override void InitializeTask()
        {
            base.InitializeTask();
            

            for (int i = 0; i < locations.Length; i++)
            {
                var coin = Instantiate(coinPrefab, locations[i], Quaternion.identity);
                coin.OnCoinCollected += CoinCollect;
                coin.HideMe();
                spawnedCoins.Add(coin);
            }
            Debug.Log("SingleTask Concrete Initialize");
        }

        

        private void CoinCollect()
        {
            collectedCoinsAmount++;
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
            Debug.Log("SingleTask Concrete Start");
        }

        public override void CompleteTask()
        {
            base.CompleteTask();
            Debug.Log("Single Task Completed");
        }
    }
}