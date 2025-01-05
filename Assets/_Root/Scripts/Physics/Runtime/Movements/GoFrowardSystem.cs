using Unity.Burst;
using Unity.Entities;

namespace _Root.Scripts.Physics.Runtime.Movements
{
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup), OrderLast = true)]
    public partial struct GoFrowardSystem : ISystem
    {

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            GoFrowardJobEntity job = new GoFrowardJobEntity();
            job.ScheduleParallel();
        }
    }
}