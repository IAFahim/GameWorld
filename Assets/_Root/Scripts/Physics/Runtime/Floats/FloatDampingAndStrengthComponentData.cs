using Unity.Entities;

namespace _Root.Scripts.Physics.Runtime.Floats
{
    public struct FloatDampingAndStrengthComponentData : IComponentData
    {
        public float Damping;
        public float Strength;
    }
}