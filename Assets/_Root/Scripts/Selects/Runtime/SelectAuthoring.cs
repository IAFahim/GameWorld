using _Root.Scripts.Data.Runtime.Selecteds;
using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.Selects.Runtime
{
    public class SelectAuthoring : MonoBehaviour
    {
        public class SelectedComponentDataBaker : Baker<SelectAuthoring>
        {
            public override void Bake(SelectAuthoring authoring)
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