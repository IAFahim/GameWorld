using _Root.Scripts.Directions.Runtime;
using Unity.Burst;
using Unity.Entities;

namespace _Root.Scripts.Physics.Runtime.Rotates
{
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup), OrderFirst = true)]
    public partial struct RotatePIDSystem : ISystem
    {
        public EntityQuery _query;
        
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<DirectionComponentData>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var job = new RotatePIDJobEntity()
            {
                DeltaTime = SystemAPI.Time.DeltaTime
            };
            job.ScheduleParallel();
        }
    }
}