using Unity.Burst;
using Unity.Entities;

namespace _Root.Scripts.Mains.Runtime.References
{
    public partial struct MainEntityReferenceSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            int highestOrder = int.MinValue;
            var highestOrderEntity = Entity.Null;
            foreach (
                (RefRO<MainEntityStackTagComponentData> mainEntityComponentData, Entity entity)
                in SystemAPI.Query<RefRO<MainEntityStackTagComponentData>>().WithEntityAccess())
            {
                if (mainEntityComponentData.ValueRO.StackOrder > highestOrder)
                {
                    highestOrder = mainEntityComponentData.ValueRO.StackOrder;
                    highestOrderEntity = entity;
                }
            }

            var mainEntitySingleton = SystemAPI.GetSingletonRW<MainEntityReferenceSingletonComponentData>();
            mainEntitySingleton.ValueRW = new MainEntityReferenceSingletonComponentData()
            {
                MainEntities = highestOrderEntity,
                StackOrder = highestOrder
            };
        }
    }
}