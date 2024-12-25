using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

namespace _Root.Scripts.Physics.Runtime.Floats
{
    [BurstCompile]
    public partial struct FloatOverWaterJobEntity : IJobEntity
    {
        public float WaterHeight;

        private void Execute(in LocalTransform localTransform, ref PhysicsVelocity physicsVelocity,
            in FloatDampingAndStrengthComponentData floatDampingAndStrength)
        {
            var buoyancyForce = BuoyancyForce(
                WaterHeight,
                localTransform.Position,
                physicsVelocity.Linear,
                floatDampingAndStrength.Damping, floatDampingAndStrength.Strength
            );

            physicsVelocity.Linear += buoyancyForce;
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