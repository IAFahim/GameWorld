using _Root.Scripts.Data.Runtime.Offsets;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace _Root.Scripts.ECS.Authorings.Runtime.Offsets
{
    public class CenterOffsetAuthoring : MonoBehaviour
    {
        public float3 centerOffset = new(0, 1, 0);

        public class CenterOffsetBaker : Baker<CenterOffsetAuthoring>
        {
            public override void Bake(CenterOffsetAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new CenterOffsetComponentData
                {
                    Offset = authoring.centerOffset
                });
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.TransformPoint(centerOffset), 0.1f);
        }
    }
}