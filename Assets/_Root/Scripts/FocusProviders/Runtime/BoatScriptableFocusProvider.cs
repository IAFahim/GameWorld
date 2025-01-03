using _Root.Scripts.Directions.Runtime;
using _Root.Scripts.Mains.Runtime.AbstractFocusProvider;
using _Root.Scripts.Mains.Runtime.References;
using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace _Root.Scripts.FocusProviders.Runtime
{
    [CreateAssetMenu(fileName = "BoatScriptableFocusProvider", menuName = "Scriptable/Focus/BoatFocusProvider",
        order = 0)]
    public class BoatScriptableFocusProvider : AbstractScriptableFocusProvider
    {
        public InputActionReference inputActionReference;
        public Vector3 direction;
        public float changeSpeed;
        public float threshold;
        [FormerlySerializedAs("held")] public bool isHeld;


        public override void Change(ref SystemState state,
            MainEntityReferenceSingletonComponentData mainEntityReference)
        {
            inputActionReference.action.Enable();
            inputActionReference.action.performed += OnActionPerformed;
            inputActionReference.action.canceled += OnActionCanceled;
        }

        private void OnActionCanceled(InputAction.CallbackContext obj)
        {
            isHeld = false;
        }

        private void OnActionPerformed(InputAction.CallbackContext ctx)
        {
            isHeld = true;
            var input = ctx.ReadValue<Vector2>();
            direction = new Vector3(input.x, 0, input.y);
        }

        public override void Tick(ref SystemState state, MainEntityReferenceSingletonComponentData mainEntityReference)
        {
            if (!isHeld) return;
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var directionComponentData =
                entityManager.GetComponentData<DirectionComponentData>(mainEntityReference.MainEntity);

            directionComponentData.Normalized = direction;
            // var dot = 1 - Mathf.Abs(Vector3.Dot(directionComponentData.Normalized, direction));
            // Debug.Log(dot);
            // if (threshold < dot) return;
            entityManager.SetComponentData(mainEntityReference.MainEntity, directionComponentData);
        }

        public override void Forget()
        {
            inputActionReference.action.performed -= OnActionPerformed;
            inputActionReference.action.canceled -= OnActionCanceled;
            inputActionReference.action.Disable();
            direction = Vector3.zero;
            isHeld = false;
        }
    }
}