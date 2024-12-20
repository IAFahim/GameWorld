using _Root.Scripts.Data.Runtime.Physics;
using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.ECS.Authorings.Runtime.Physics
{
    public class KeepAfloatTagAuthoring : MonoBehaviour
    {
        public class KeepUpRightTagComponentDataBaker : Baker<KeepAfloatTagAuthoring>
        {
            public override void Bake(KeepAfloatTagAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<KeepAfloatTagComponentData>(entity);
            }
        }
    }
}