using _Root.Scripts.Mains.Runtime.References;
using BovineLabs.Core.Extensions;
using BovineLabs.Core.ObjectManagement;
using Unity.Entities;

namespace _Root.Scripts.Inputs.Runtime
{
    [UpdateAfter(typeof(MainEntityReferenceSystem))]
    public partial struct ScriptableInputSystem : ISystem
    {
        [Unity.Burst.BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<MainEntityReferenceSingletonComponentData>();
        }

        public void OnUpdate(ref SystemState state)
        {
            var mainEntityReference = SystemAPI.GetSingleton<MainEntityReferenceSingletonComponentData>();
            var objectId = SystemAPI.GetComponentRO<ObjectId>(mainEntityReference.MainEntity);
            ScriptableInputSingleton.Instance.UpdateForMod(objectId.ValueRO, mainEntityReference.MainEntity);
        }
    }
}