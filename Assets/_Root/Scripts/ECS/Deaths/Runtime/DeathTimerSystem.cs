using _Root.Scripts.Data.Runtime.Deaths;
using BovineLabs.Core.LifeCycle;
using Unity.Burst;
using Unity.Entities;

namespace _Root.Scripts.ECS.Deaths.Runtime
{
    public partial struct DeathTimerSystem : ISystem
    {
        private DestroyTimer<DeathTimerComponentData> _destroyTimer;
        
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