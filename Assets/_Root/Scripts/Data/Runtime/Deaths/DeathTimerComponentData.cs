using Unity.Entities;

namespace _Root.Scripts.Data.Runtime.Deaths
{
    public struct DeathTimerComponentData : IComponentData, IEnableableComponent
    {
        public float RemainingAliveTime;
    }
}
