using _Root.Scripts.Directions.Runtime;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

namespace _Root.Scripts.Physics.Runtime.Rotates
{
    [BurstCompile]
    public partial struct RotatePIDJobEntity : IJobEntity
    {
        public float DeltaTime;

        [BurstCompile]
        private void Execute(
            ref PhysicsVelocity physicsVelocity,
            ref RotatePIDComponentData rotatePid,
            in LocalTransform localTransform,
            in DirectionComponentData direction
        )
        {
            // Calculate target and current angles in degrees
            float targetAngle = math.atan2(direction.Normalized.x, direction.Normalized.z);
            float currentAngle = math.atan2(math.forward(localTransform.Rotation).x,
                math.forward(localTransform.Rotation).z);

            // Calculate error and normalize it
            float error = NormalizeAngleRadians(targetAngle - currentAngle);

            // Update rotation
            rotatePid = Update(rotatePid, error, DeltaTime, out var torque);
            physicsVelocity.Angular += new float3(0, 0, math.radians(torque));
        }

        [BurstCompile]
        private static float NormalizeAngleRadians(float angle)
        {
            // Normalize angle to -π to π range (radians)
            angle = math.fmod(angle + math.PI, 2 * math.PI);
            if (angle < 0)
                angle += 2 * math.PI;
            return angle - math.PI;
        }

        [BurstCompile]
        private RotatePIDComponentData Update(RotatePIDComponentData rotate, float error,
            float deltaTime, out float value)
        {
            rotate.IntegralError = math.clamp(rotate.IntegralError + error * deltaTime, rotate.Low, rotate.High);
            if (math.abs(error) < rotate.ErrorThreshold)
            {
                rotate.IntegralError = 0;
                value = 0;
                return rotate;
            }

            var derivative = (error - rotate.PreviousError) / deltaTime;
            rotate.PreviousError = error;
            value = rotate.PropertionalGainDelta * error
                    + rotate.IntegralGainDelta * rotate.IntegralError
                    + rotate.DeriativeGainDelta * derivative;
            return rotate;
        }
    }
}