using _Root.Scripts.AttractionAndAvoidances.Runtime;
using _Root.Scripts.Directions.Runtime;
using _Root.Scripts.Mains.Runtime.References;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace _Root.Scripts.Sensors.Runtime
{
    public partial struct DirectionControlAttractionAndAvoidanceSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<MainEntityReferenceSingletonComponentData>();
            state.RequireForUpdate<AttractionAndAvoidanceComponentData>();
            state.RequireForUpdate<DirectionComponentData>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var mainEntity = SystemAPI.GetSingleton<MainEntityReferenceSingletonComponentData>();
            if (!SystemAPI.HasComponent<LocalTransform>(mainEntity.MainEntity)) return;
            var mainEntityLocalTransform = SystemAPI.GetComponent<LocalTransform>(mainEntity.MainEntity);
            foreach (
                var (
                    attractionAndAvoidanceComponentData,
                    directionComponentData,
                    localTransform
                    ) in SystemAPI.Query<
                    RefRO<AttractionAndAvoidanceComponentData>,
                    RefRW<DirectionComponentData>,
                    RefRO<LocalTransform>
                >())
            {
                int mainEntityPriority = attractionAndAvoidanceComponentData.ValueRO.MainEntityPriority;
                directionComponentData.ValueRW.Direction = math.normalize(
                    mainEntityLocalTransform.Position - localTransform.ValueRO.Position
                );
            }
        }
    }
}