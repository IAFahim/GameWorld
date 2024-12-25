using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.Mains.Runtime
{
    public class MainTagAuthoring : MonoBehaviour
    {
        public bool isMain;

        public class MainTagBaker : Baker<MainTagAuthoring>
        {
            public override void Bake(MainTagAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new MainTagComponentData());
                SetComponentEnabled<MainTagComponentData>(entity, authoring.isMain);
            }
        }
    }
}