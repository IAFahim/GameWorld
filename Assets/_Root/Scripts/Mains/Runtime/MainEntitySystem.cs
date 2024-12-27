using BovineLabs.Core.Extensions;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

namespace _Root.Scripts.Mains.Runtime
{
    public partial struct MainEntitySystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var mainEntitySingleton = SystemAPI.GetSingletonRW<MainEntitySingleton>();
            var mainOrderNativeList = new NativeList<Entity>(4, Allocator.Temp);
            foreach (var mainEntityComponentData in SystemAPI.Query<RefRO<MainEntityComponentData>>())
            {
                // mainOrderNativeList.Add(mainEntityComponentData.Value.Entity);
            }
        }
    }
}