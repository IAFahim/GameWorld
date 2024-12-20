using _Root.Scripts.Tags.Runtime.Selecteds;
using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.ECS.Authorings.Runtime.Selecteds
{
    public class SelectedTagComponentDataAuthoring : MonoBehaviour
    {
        public class SelectedTagComponentDataBaker : Baker<SelectedTagComponentDataAuthoring>
        {
            public override void Bake(SelectedTagComponentDataAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new SelectedTagComponentData());
                SetComponentEnabled<SelectedTagComponentData>(entity, false);
            }
        }
    }
}