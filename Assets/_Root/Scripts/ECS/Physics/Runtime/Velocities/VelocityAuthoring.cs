using _Root.Scripts.Data.Runtime.Physics;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace _Root.Scripts.ECS.Physics.Runtime.Velocities
{
    public class VelocityAuthoring : MonoBehaviour
    {
        public float3 linearVelocity;
        public float3 angularVelocity;

        public class VelocityComponentDataBaker : Baker<VelocityAuthoring>
        {
            public override void Bake(VelocityAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity,
                    new VelocityComponentData
                    {
                        LinearVelocity = authoring.linearVelocity,
                        AngularVelocity = authoring.angularVelocity
                    }
                );
            }
        }
    }
}