using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.Mains.Runtime
{
    public class MainEntityStackTagAuthoring : MonoBehaviour
    {
        public bool isMain;

        public class MainTagBaker : Baker<MainEntityStackTagAuthoring>
        {
            public override void Bake(MainEntityStackTagAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new MainEntityStackTagComponentData());
                SetComponentEnabled<MainEntityStackTagComponentData>(entity, authoring.isMain);
            }
        }
    }
}