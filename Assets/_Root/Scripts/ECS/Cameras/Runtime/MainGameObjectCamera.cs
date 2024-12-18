using UnityEngine;

namespace _Root.Scripts.ECS.Cameras.Runtime
{
    public class MainGameObjectCamera : MonoBehaviour
    {
        public static Camera Instance;

        void Awake()
        {
            Instance = GetComponent<UnityEngine.Camera>();
        }
    }
}