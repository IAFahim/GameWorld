using _Root.Scripts.ECS.Authorings.Runtime.ObjectIDs;
using _Root.Scripts.Tags.Runtime.Mains;
using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.ECS.Authorings.Runtime.Mains
{
    [RequireComponent(typeof(ObjectIdAuthoring))]
    public class IsMainTagAuthoring : MonoBehaviour
    {
        public bool isMain;

        public class IsMainTagBaker : Baker<IsMainTagAuthoring>
        {
            public override void Bake(IsMainTagAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new MainTagComponentData());
                SetComponentEnabled<MainTagComponentData>(entity, authoring.isMain);
            }
        }
    }
}