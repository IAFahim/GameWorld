﻿using _Root.Scripts.Directions.Runtime;
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
            float currentAngle = math.atan2(direction.Normalized.x, direction.Normalized.z);
            float3 forward = math.forward(localTransform.Rotation);
            float targetAngle = math.atan2(forward.x, forward.z);

            // Calculate shortest rotation difference
            float delta = NormalizeAngleRadians(currentAngle - targetAngle);

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
            physicsVelocity.Angular.z += finalTorque;
        }

        [BurstCompile]
        private static float NormalizeAngleRadians(float angle)
        {
            // Normalize angle to -π to π range (radians)
            angle = math.fmod(angle + math.PI, 2 * math.PI);
            if (angle < 0) angle += 2 * math.PI;
            return angle - math.PI;
        }
    }
}