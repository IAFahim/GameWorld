using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace _Root.Scripts.Physics.Runtime.Rotates
{
    [BurstCompile]
    public struct RotatePIDComponentData : IComponentData
    {
        public float PropertionalGainDelta; // Proportional gain
        public float IntegralGainDelta; // Integral gain
        public float DeriativeGainDelta; // Derivative gain

        public float IntegralError; // Accumulated error
        public float PreviousError; // Last frame's error
        public float ErrorThreshold; // Minimum error to consider "settled"

        public float Low;
        public float High;
    }
}