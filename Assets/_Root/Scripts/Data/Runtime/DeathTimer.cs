using Unity.Entities;

namespace _Root.Scripts.Data.Runtime
{
    public struct DeathTimer : IComponentData
    {
        public float RemainingAliveTime;
    }
}
