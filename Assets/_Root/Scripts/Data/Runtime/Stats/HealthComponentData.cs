using Unity.Entities;

namespace _Root.Scripts.Data.Runtime.Stats
{
    public struct HealthComponentData : IComponentData
    {
        public float CurrentHealth;
        public float MaxHealth;
    }
}