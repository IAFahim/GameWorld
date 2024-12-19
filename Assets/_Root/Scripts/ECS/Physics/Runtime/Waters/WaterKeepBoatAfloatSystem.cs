using _Root.Scripts.Data.Runtime.Waters;
using BovineLabs.Core;
using BovineLabs.Core.Extensions;
using Unity.Burst;
using Unity.Entities;

namespace _Root.Scripts.ECS.Physics.Runtime.Waters
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial struct WaterKeepBoatAfloatSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<BLDebug>();
            state.RequireForUpdate<WaterHeightComponentData>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var waterHeight = state.GetSingleton<WaterHeightComponentData>();
            var blDebug = state.GetSingleton<BLDebug>(false);
            blDebug.Debug($"waterHeight: {waterHeight.WaterHeight}");
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }
    }
}