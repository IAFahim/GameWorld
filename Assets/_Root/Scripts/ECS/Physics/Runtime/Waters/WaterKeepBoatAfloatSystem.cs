using _Root.Scripts.Data.Runtime.Physics;
using _Root.Scripts.Data.Runtime.Waters;
using _Root.Scripts.Tags.Runtime.Physics;
using BovineLabs.Core.Extensions;
using Unity.Burst;
using Unity.Entities;
using Unity.Physics;
using Unity.Transforms;

namespace _Root.Scripts.ECS.Physics.Runtime.Waters
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial struct WaterKeepBoatAfloatSystem : ISystem
    {
        private EntityQuery _query;

        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<WaterInfoComponentData>();
            _query = SystemAPI.QueryBuilder()
                .WithAll<LocalTransform>()
                .WithAll<DampingStrengthComponentData>()
                .WithAll<PhysicsVelocity>()
                .WithPresent<KeepAfloatTagComponentData>()
                .Build();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var waterInfoComponentData = state.GetSingleton<WaterInfoComponentData>();
            var job = new WaterKeepBoatAfloatJobEntity
            {
                WaterHeight = waterInfoComponentData.WaterHeight
            };
            job.ScheduleParallel();
        }
    }
}