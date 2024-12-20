using _Root.Scripts.Data.Runtime.Physics;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

namespace _Root.Scripts.ECS.Physics.Runtime.Waters
{
    [BurstCompile]
    public partial struct WaterKeepBoatAfloatJobEntity : IJobEntity
    {
        public float WaterHeight;

        private void Execute(in LocalTransform localTransform, ref PhysicsVelocity physicsVelocity,
            in DampingStrengthComponentData damping)
        {
            var buoyancyForce = BuoyancyForce(
                WaterHeight,
                localTransform.Position,
                physicsVelocity.Linear,
                damping.Damping, damping.Strength
            );

            physicsVelocity = new PhysicsVelocity
            {
                Linear = physicsVelocity.Linear + buoyancyForce,
                Angular = physicsVelocity.Angular
            };
        }

        [BurstCompile]
        private float3 BuoyancyForce(float waterHeight, float3 position, float3 velocity, float damping, float strength)
        {
            if (position.y > waterHeight) return float3.zero;

            var downVelocity = velocity.y;
            var submergedDepth = waterHeight - position.y;
            var force = submergedDepth * strength - downVelocity * damping;
            return force * math.up();
        }
    }
}