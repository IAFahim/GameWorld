using _Root.Scripts.Directions.Runtime;
using BovineLabs.Core.ObjectManagement;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace _Root.Scripts.Inputs.Runtime
{
    [CreateAssetMenu(fileName = "BoatScriptableModInputManager", menuName = "Scriptable/Input/BoatInputManager",
        order = 0)]
    public class BoatScriptableModInputManager : AbstractScriptableModInputManger
    {
        public override void UpdateForMod(int index, ObjectId objectId, Entity entity)
        {
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var directionComponentData = entityManager.GetComponentData<DirectionComponentData>(entity);
            directionComponentData.Direction = new float3(1, 0, 0);
            entityManager.SetComponentData(entity, directionComponentData);
        }

        public override void ClearFormMod(ObjectId objectId)
        {
        }
    }
}