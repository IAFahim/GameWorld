using _Root.Scripts.Directions.Runtime;
using _Root.Scripts.Mains.Runtime.AbstractFocusProvider;
using _Root.Scripts.Mains.Runtime.References;
using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Root.Scripts.FocusProviders.Runtime
{
    [CreateAssetMenu(fileName = "BoatScriptableFocusProvider", menuName = "Scriptable/Focus/BoatFocusProvider",
        order = 0)]
    public class BoatScriptableFocusProvider : AbstractScriptableFocusProvider
    {
        public InputActionReference inputActionReference;
        public Vector3 direction;
        public float changeSpeed;
        public bool held;


        public override void Change(ref SystemState state,
            MainEntityReferenceSingletonComponentData mainEntityReference)
        {
            inputActionReference.action.Enable();
            inputActionReference.action.performed += OnActionPerformed;
            inputActionReference.action.canceled += OnActionCanceled;
        }

        private void OnActionCanceled(InputAction.CallbackContext obj)
        {
            held = false;
        }

        private void OnActionPerformed(InputAction.CallbackContext ctx)
        {
            held = true;
            var input = ctx.ReadValue<Vector2>();
            direction = new Vector3(input.x, 0, input.y);
        }

        public override void Tick(ref SystemState state, MainEntityReferenceSingletonComponentData mainEntityReference)
        {
            if (!held) return;
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var directionComponentData =
                entityManager.GetComponentData<DirectionComponentData>(mainEntityReference.MainEntity);
            directionComponentData.Direction = Vector3.Lerp(
                directionComponentData.Direction, direction, changeSpeed * Time.deltaTime
            );
            entityManager.SetComponentData(mainEntityReference.MainEntity, directionComponentData);
        }

        public override void Forget()
        {
            inputActionReference.action.performed -= OnActionPerformed;
            inputActionReference.action.canceled -= OnActionCanceled;
            inputActionReference.action.Disable();
            direction = Vector3.zero;
            held = false;
        }
    }
}