using _Root.Scripts.Data.Runtime;
using Unity.Burst;
using Unity.Entities;

namespace _Root.Scripts.ECS.Physics.Runtime.Rotates
{
    public partial struct RotateDampingAndStrengthSystem : ISystem
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
            var job = new RotateDampingAndStrengthJobEntity();
            job.ScheduleParallel();
        }
    }
}