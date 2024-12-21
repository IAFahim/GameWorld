using _Root.Scripts.Data.Runtime.Selecteds;
using Sirenix.OdinInspector;
using Unity.Entities;
using Unity.Physics;
using Unity.Physics.Authoring;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace _Root.Scripts.Hybrids.Runtime.Selects
{
    public class SelectedEntitiyManangerMonoBehavior : MonoBehaviour
    {
        public Camera mainCamera;
        public EventSystem eventSystem;
        public PhysicsCategoryTags belongsTo;
        public PhysicsCategoryTags collidesWith;
        public int groupIndex = 0;
        public float maxDistance = 100f;

        [ShowInInspector] [ReadOnly] private Entity _selectedEntity;
        private CollisionFilter _collisionFilter;
        
        protected void Update()
        {
            if (eventSystem.IsPointerOverGameObject()) return;
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
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var collisionWorld = entityManager.CreateEntityQuery(typeof(PhysicsWorldSingleton))
                .GetSingleton<PhysicsWorldSingleton>()
                .PhysicsWorld.CollisionWorld;
            _collisionFilter = new CollisionFilter
            {
                BelongsTo = belongsTo.Value,
                CollidesWith = collidesWith.Value,
                GroupIndex = groupIndex
            };

            PerformRayCast(readValue, ref collisionWorld, ref entityManager);
        }

        private void PerformRayCast(
            Vector2 readValue,
            ref CollisionWorld collisionWorld,
            ref EntityManager entityManager
        )
        {
            var ray = mainCamera.ScreenPointToRay(readValue);
            if (collisionWorld.CastRay(new RaycastInput
                {
                    Start = ray.origin,
                    End = ray.origin + ray.direction * maxDistance,
                    Filter = _collisionFilter
                }, out var hit))
            {
                _selectedEntity = collisionWorld.Bodies[hit.RigidBodyIndex].Entity;
                entityManager.SetComponentEnabled<SelectedTagComponentData>(_selectedEntity, true);
                entityManager.SetComponentData(_selectedEntity, new SelectedTagComponentData()
                {
                    EnabledThisFrame = true
                });
                Debug.DrawLine(ray.origin, hit.Position, Color.green, 1f);
            }
            else
            {
                if (
                    _selectedEntity != Entity.Null &&
                    entityManager.Exists(_selectedEntity) &&
                    entityManager.HasComponent<SelectedTagComponentData>(_selectedEntity)
                )
                {
                    entityManager.SetComponentEnabled<SelectedTagComponentData>(_selectedEntity, false);
                    _selectedEntity = Entity.Null;
                    Debug.DrawLine(ray.origin, ray.origin + ray.direction * maxDistance, Color.red, 1f);
                }
                else
                {
                    Debug.DrawLine(ray.origin, ray.origin + ray.direction * maxDistance, Color.blue, 1f);
                }
            }
        }
    }
}