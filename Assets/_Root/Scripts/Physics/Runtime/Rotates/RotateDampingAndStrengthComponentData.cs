using Unity.Entities;

namespace _Root.Scripts.Physics.Runtime.Rotates
{
    public struct RotateDampingAndStrengthComponentData : IComponentData
    {
        public float Damping;
        public float Strength;
        public float Accuracy;
    }
}