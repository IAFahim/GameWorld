using _Root.Scripts.Data.Runtime.Physics;
using _Root.Scripts.Data.Runtime.Waters;
using BovineLabs.Core.Extensions;
using Unity.Burst;
using Unity.Entities;
using Unity.Physics;
using Unity.Transforms;

namespace _Root.Scripts.ECS.Physics.Runtime.Waters
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
            var waterInfoComponentData = state.GetSingleton<WaterInfoComponentData>();
            var job = new FloatOverWaterJobEntity
            {
                WaterHeight = waterInfoComponentData.WaterHeight
            };
            job.ScheduleParallel();
        }
    }
}