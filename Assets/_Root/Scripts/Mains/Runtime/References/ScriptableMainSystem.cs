using Unity.Entities;

namespace _Root.Scripts.Mains.Runtime.References
{
    [UpdateAfter(typeof(MainEntityReferenceSystem))]
    public partial struct ScriptableMainSystem : ISystem
    {
        [Unity.Burst.BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<MainEntityReferenceSingletonComponentData>();
        }

        public void OnUpdate(ref SystemState state)
        {
            var mainEntityReference = SystemAPI.GetSingleton<MainEntityReferenceSingletonComponentData>();
            ScriptableMainReferenceMiddlewareSingleton.Instance.Process(ref state, mainEntityReference);
        }
    }
}