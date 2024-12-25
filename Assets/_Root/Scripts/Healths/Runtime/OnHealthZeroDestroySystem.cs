using BovineLabs.Core.LifeCycle;
using Unity.Burst;
using Unity.Entities;

namespace _Root.Scripts.Healths.Runtime
{
    [UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = true)]
    [UpdateBefore((typeof(EndSimulationEntityCommandBufferSystem)))]
    public partial struct OnHealthZeroDestroySystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (
                var (
                    healthComponentData,
                    entity
                    ) in SystemAPI.Query<
                    RefRW<HealthComponentData>
                >().WithDisabled<DestroyEntity>().WithEntityAccess()
            )
            {
                if (healthComponentData.ValueRO.CurrentHealth > 0) return;
                state.EntityManager.SetComponentEnabled<DestroyEntity>(entity, true);
            }
        }
    }
}