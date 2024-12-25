using Unity.Entities;

namespace _Root.Scripts.Healths.Runtime
{
    public struct HealthComponentData : IComponentData
    {
        public float CurrentHealth;
        public float MaxHealth;
    }
}