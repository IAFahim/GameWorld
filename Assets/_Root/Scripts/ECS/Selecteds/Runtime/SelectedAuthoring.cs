using _Root.Scripts.Data.Runtime.Selecteds;
using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.ECS.Selecteds.Runtime
{
    public class SelectedAuthoring : MonoBehaviour
    {
        public class SelectedComponentDataBaker : Baker<SelectedAuthoring>
        {
            public override void Bake(SelectedAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new SelectedComponentData
                {
                    TimeSceneEnabled = 0
                });
                SetComponentEnabled<SelectedComponentData>(entity, false);
            }
        }
    }
}