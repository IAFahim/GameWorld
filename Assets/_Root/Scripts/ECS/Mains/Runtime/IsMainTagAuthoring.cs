using _Root.Scripts.Data.Runtime.Mains;
using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.ECS.Mains.Runtime
{
    public class IsMainTagAuthoring : MonoBehaviour
    {
        public class IsMainTagBaker : Baker<IsMainTagAuthoring>
        {
            public override void Bake(IsMainTagAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new MainSingletonComponentData());
            }
        }
    }
}