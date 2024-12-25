using UnityEngine;

namespace _Root.Scripts.ManagedReferenceProviders.Runtime
{
    public abstract class AbstractMainReferenceInstanceProviderMonoBehaviour<T> : MonoBehaviour
    {
        public static T Instance { get; protected set; }

        [SerializeField] private T instance;

        void Awake() => Instance = instance;

        protected void Reset() => instance = GetComponent<T>();
    }
}