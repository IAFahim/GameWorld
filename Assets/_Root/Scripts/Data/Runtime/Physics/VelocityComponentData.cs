using Unity.Entities;
using Unity.Mathematics;

namespace _Root.Scripts.Data.Runtime.Physics
{
    public struct VelocityComponentData : IComponentData
    {
        public float3 LinearVelocity;
        public float3 AngularVelocity;
    }
}