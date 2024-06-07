using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeLogic.Task_Manager
{
    public class CoinTrigger : MonoBehaviour
    {
        public Action OnCoinCollected;
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerController>())
            {
                OnCoinCollected?.Invoke();
                Destroy(gameObject);
            }
        }

        public void HideMe()
        {
            gameObject.SetActive(false);
        }
        public void UnhideMe()
        {
            gameObject.SetActive(true);
        }
    }
}