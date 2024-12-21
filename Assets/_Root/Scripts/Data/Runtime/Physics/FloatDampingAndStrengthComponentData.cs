using Unity.Entities;

namespace _Root.Scripts.Data.Runtime.Physics
{
    public struct FloatDampingAndStrengthComponentData : IComponentData
    {
        public float Damping;
        public float Strength;
    }
}