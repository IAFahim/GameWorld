using Unity.Entities;
using Unity.Mathematics;

namespace _Root.Scripts.Physics.Runtime.Velocitys
{
    public struct VelocityComponentData : IComponentData
    {
        public float3 LinearVelocity;
        public float3 AngularVelocity;
    }
}