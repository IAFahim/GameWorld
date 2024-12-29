using BovineLabs.Core.ObjectManagement;
using Unity.Burst;
using Unity.Entities;

namespace _Root.Scripts.Mains.Runtime.References
{
    public partial struct MainEntityReferenceSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var mainEntitySingleton = SystemAPI.GetSingletonRW<MainEntityReferenceSingletonComponentData>();
            int highestOrder = int.MinValue;
            var highestOrderEntity = Entity.Null;
            foreach (
                (RefRO<MainEntityStackTagComponentData> mainEntityComponentData, Entity entity)
                in SystemAPI.Query<RefRO<MainEntityStackTagComponentData>>().WithAll<ObjectId>().WithEntityAccess())
            {
                if (mainEntityComponentData.ValueRO.StackOrder > highestOrder)
                {
                    highestOrder = mainEntityComponentData.ValueRO.StackOrder;
                    highestOrderEntity = entity;
                }
            }

            if (highestOrderEntity == Entity.Null)
            {
                mainEntitySingleton.ValueRW = new MainEntityReferenceSingletonComponentData()
                {
                    MainEntity = Entity.Null,
                    StackOrder = 0,
                    IsChangedThisFrame = false,
                    IsPresent = false,
                    Mod = 0,
                    Id = 0
                };
                return;
            }

            if (mainEntitySingleton.ValueRW.MainEntity == highestOrderEntity)
            {
                mainEntitySingleton.ValueRW = new MainEntityReferenceSingletonComponentData()
                {
                    MainEntity = highestOrderEntity,
                    StackOrder = highestOrder,
                    IsChangedThisFrame = false,
                    IsPresent = true,
                    Mod = mainEntitySingleton.ValueRO.Mod,
                    Id = mainEntitySingleton.ValueRO.Id
                };
                return;
            }

            var objectId = SystemAPI.GetComponentRO<ObjectId>(highestOrderEntity);
            mainEntitySingleton.ValueRW = new MainEntityReferenceSingletonComponentData()
            {
                MainEntity = highestOrderEntity,
                StackOrder = highestOrder,
                IsChangedThisFrame = true,
                IsPresent = true,
                Mod = objectId.ValueRO.Mod,
                Id = objectId.ValueRO.ID
            };
        }
    }
}