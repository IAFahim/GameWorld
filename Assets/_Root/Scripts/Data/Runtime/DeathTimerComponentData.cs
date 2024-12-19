using Unity.Entities;

namespace _Root.Scripts.Data.Runtime
{
    public struct DeathTimerComponentData : IComponentData, IEnableableComponent
    {
        public float RemainingAliveTime;
    }
}
