using Unity.Entities;

namespace _Root.Scripts.Data.Runtime
{
    public struct HealthComponentData : IComponentData
    {
        public float Health;
        public float MaxHealth;
    }
}