using _Root.Scripts.Data.Runtime.Waters;
using Unity.Burst;
using Unity.Entities;

namespace _Root.Scripts.Physics.Runtime.Floats
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial struct FloatOverWaterSystem : ISystem
    {

        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<WaterInfoComponentData>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var waterInfoComponentData = SystemAPI.GetSingleton<WaterInfoComponentData>();
            var job = new FloatOverWaterJobEntity
            {
                WaterHeight = waterInfoComponentData.WaterHeight
            };
            job.ScheduleParallel();
        }
    }
}