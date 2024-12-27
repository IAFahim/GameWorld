using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.Mains.Runtime
{
    public class MainEnitityTagAuthoring : MonoBehaviour
    {
        public bool isMain;

        public class MainTagBaker : Baker<MainEnitityTagAuthoring>
        {
            public override void Bake(MainEnitityTagAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new MainEntityTagComponentData());
                SetComponentEnabled<MainEntityTagComponentData>(entity, authoring.isMain);
            }
        }
    }
}