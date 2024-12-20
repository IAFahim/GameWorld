using _Root.Scripts.Tags.Runtime.Mains;
using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.ECS.Authorings.Runtime.Mains
{
    public class IsMainTagAuthoring : MonoBehaviour
    {
        public class IsMainTagBaker : Baker<IsMainTagAuthoring>
        {
            public override void Bake(IsMainTagAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<IsMainTagComponentData>(entity);
            }
        }
    }
}