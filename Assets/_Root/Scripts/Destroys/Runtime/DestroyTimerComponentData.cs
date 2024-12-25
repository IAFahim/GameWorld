using Unity.Entities;

namespace _Root.Scripts.Destroys.Runtime
{
    public struct DestroyTimerComponentData : IComponentData, IEnableableComponent
    {
        public float RemainingAliveTime;
    }
}
