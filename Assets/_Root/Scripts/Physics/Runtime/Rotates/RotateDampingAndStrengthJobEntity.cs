using _Root.Scripts.Data.Runtime;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

namespace _Root.Scripts.Physics.Runtime.Rotates
{
    [BurstCompile]
    public partial struct RotateDampingAndStrengthJobEntity : IJobEntity
    {
        [BurstCompile]
        private void Execute(
            ref PhysicsVelocity physicsVelocity,
            in LocalTransform localTransform,
            in DirectionComponentData direction,
            in RotateDampingAndStrengthComponentData rotateDampingAndStrength
        )
        {
            float currentAngle = math.degrees(math.atan2(direction.Direction.x, direction.Direction.z));
            float3 forward = localTransform.Forward();
            float targetAngle = math.degrees(math.atan2(forward.x, forward.z));

            // Calculate shortest rotation difference
            float delta = NormalizeAngle(currentAngle - targetAngle);

            // Early exit if nearly aligned
            float deltaAbs = math.abs(delta);
            if (deltaAbs < rotateDampingAndStrength.Accuracy)
            {
                physicsVelocity.Angular.z = 0f;
                return;
            }

            // Calculate torque with smoothing
            float desiredTorque = delta * rotateDampingAndStrength.Strength;
            float dampingTorque = physicsVelocity.Angular.y * rotateDampingAndStrength.Damping;
            float finalTorque = desiredTorque - dampingTorque;

            // Limit maximum torque to prevent overshooting
            float strength = rotateDampingAndStrength.Strength;
            finalTorque = math.clamp(finalTorque, -strength, strength);
            physicsVelocity.Angular.z = finalTorque;
        }

        [BurstCompile]
        private static float NormalizeAngle(float angle)
        {
            // Normalize angle to -180 to 180 range
            angle %= 360f;
            if (angle > 180f)
                angle -= 360f;
            else if (angle < -180f)
                angle += 360f;
            return angle;
        }
    }
}