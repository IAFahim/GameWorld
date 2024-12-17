using _Root.Scripts.ECS.Levels.Runtime;
using BovineLabs.Core;
using BovineLabs.Core.Extensions;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.ECS.LogTest.Runtime
{
    public partial struct TestLog : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var levelComponentData in SystemAPI.Query<RefRW<LevelComponentData>>())
            {
             
                levelComponentData.ValueRW.Level++;
                Debug.Log("Level:");
                state.GetSingleton<BLDebug>(false).Debug("xxxxxxxxxxxx");
            }
        }

    }
}