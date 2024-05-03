using UnityEngine;

namespace PrototypeLogic.UI_Manager
{
    public abstract class BaseWindow : MonoBehaviour
    {
        public abstract void Initialize();
        public BaseWindow CreateWindow() => Instantiate(this);
        public void DestroyWindow() => Destroy(gameObject);
    }
}
