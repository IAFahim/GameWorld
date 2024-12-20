using Unity.Entities;
using Unity.Physics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Root.Scripts.ECS.Physics.Runtime.Selects
{
    public partial class SelectSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            if (Mouse.current != null)
            {
                var leftButtonPressed = Mouse.current.leftButton.isPressed;
                if (leftButtonPressed) ProcessClick(Mouse.current.position.ReadValue());
            }
            else if (Touchscreen.current != null)
            {
                var touch = Touchscreen.current.primaryTouch;
                if (touch.press.isPressed) ProcessClick(touch.position.ReadValue());
            }
        }

        private void ProcessClick(Vector2 readValue)
        {
            var physicsWorldSingleton = SystemAPI.GetSingleton<PhysicsWorldSingleton>();
            
        }
    }
}