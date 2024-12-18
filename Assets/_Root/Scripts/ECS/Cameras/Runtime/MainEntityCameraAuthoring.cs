using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.ECS.Cameras.Runtime
{
    [DisallowMultipleComponent]
    public class MainEntityCameraAuthoring : MonoBehaviour
    {
        public class Baker : Baker<MainEntityCameraAuthoring>
        {
            public override void Bake(MainEntityCameraAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<MainEntityCamera>(entity);
            }
        }
    }
}