using _Root.Scripts.Directions.Runtime;
using _Root.Scripts.Mains.Runtime.References;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Root.Scripts.Inputs.Runtime
{
    [CreateAssetMenu(fileName = "BoatScriptableModInputManager", menuName = "Scriptable/Input/BoatProcessor",
        order = 0)]
    public class BoatScriptableInputProcessor : AbstractScriptableMainReferenceProcessor
    {
        public InputActionReference inputActionReference;
        public Vector3 direction;
        public float changeSpeed;

        public override void Set(MainEntityReferenceSingletonComponentData mainEntityReference)
        {
            inputActionReference.action.Enable();
            inputActionReference.action.performed += OnActionPerformed;
        }

        private void OnActionPerformed(InputAction.CallbackContext ctx)
        {
            direction = ctx.ReadValue<Vector2>();
        }

        public override void Tick(MainEntityReferenceSingletonComponentData mainEntityReference)
        {
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var directionComponentData =
                entityManager.GetComponentData<DirectionComponentData>(mainEntityReference.MainEntity);
            directionComponentData.Direction = new float3(direction.x, 0, direction.y);
            entityManager.SetComponentData(mainEntityReference.MainEntity, directionComponentData);
        }

        public override void Forget()
        {
            inputActionReference.action.performed -= OnActionPerformed;
            inputActionReference.action.Disable();
        }
    }
}