using _Root.Scripts.Data.Runtime.Selecteds;
using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.ECS.Authorings.Runtime.Selecteds
{
    public class SelectedTagAuthoring : MonoBehaviour
    {
        public class SelectedTagComponentDataBaker : Baker<SelectedTagAuthoring>
        {
            public override void Bake(SelectedTagAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new SelectedTagComponentData());
            }
        }
    }
}