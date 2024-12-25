using BovineLabs.Core.LifeCycle;
using Unity.Burst;
using Unity.Entities;

namespace _Root.Scripts.Destroys.Runtime
{
    public partial struct DestroyTimerSystem : ISystem
    {
        private DestroyTimer<DestroyTimerComponentData> _destroyTimer;
        
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            _destroyTimer.OnCreate(ref state);
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            _destroyTimer.OnUpdate(ref state);
        }
    }
}