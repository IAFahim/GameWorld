using _Root.Scripts.Data.Runtime.Selecteds;
using Sirenix.OdinInspector;
using Unity.Entities;
using Unity.Physics;
using Unity.Physics.Authoring;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Ray = UnityEngine.Ray;
using RaycastHit = Unity.Physics.RaycastHit;

namespace _Root.Scripts.Hybrids.Selects.Runtime
{
    public class SelectedEntityManagerHybrid : MonoBehaviour
    {
        public Camera mainCamera;
        public EventSystem eventSystem;
        public PhysicsCategoryTags belongsTo;
        public PhysicsCategoryTags collidesWith;
        public int groupIndex = 0;
        public float maxDistance = 100f;

        [ShowInInspector] [ReadOnly] private Entity _selectedEntity;
        private CollisionFilter _collisionFilter;
        private SelectedComponentData _selectedComponentData;


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

            PerformRayCast(ref entityManager, ref collisionWorld, readValue);
        }

        private void PerformRayCast(
            ref EntityManager entityManager, ref CollisionWorld collisionWorld,
            Vector2 readValue
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
                ForgetSelectedComponent(ref entityManager, ray);
                SetSelectedComponent(ref collisionWorld, ref entityManager, hit, ray);
            }
            else
            {
                if (_selectedComponentData.UnFocusEmptyClicked) ForgetSelectedComponent(ref entityManager, ray);
            }
        }

        private void ForgetSelectedComponent(ref EntityManager entityManager, Ray ray)
        {
            if (_selectedEntity != Entity.Null && entityManager.Exists(_selectedEntity))
            {
                entityManager.SetComponentEnabled<SelectedComponentData>(_selectedEntity, false);
                _selectedEntity = Entity.Null;
                Debug.DrawLine(ray.origin, ray.origin + ray.direction * maxDistance, Color.red, 1f);
            }
            else
            {
                Debug.DrawLine(ray.origin, ray.origin + ray.direction * maxDistance, Color.blue, 1f);
            }
        }

        private void SetSelectedComponent(
            ref CollisionWorld collisionWorld, ref EntityManager entityManager,
            RaycastHit hit, Ray ray
        )
        {
            _selectedEntity = collisionWorld.Bodies[hit.RigidBodyIndex].Entity;
            if (!entityManager.HasComponent<SelectedComponentData>(_selectedEntity)) return;
            _selectedComponentData = entityManager.GetComponentData<SelectedComponentData>(_selectedEntity);
            entityManager.SetComponentEnabled<SelectedComponentData>(_selectedEntity, true);
            entityManager.SetComponentData(_selectedEntity, new SelectedComponentData()
            {
                UnFocusEmptyClicked = _selectedComponentData.UnFocusEmptyClicked,
                TimeSceneEnabled = 0
            });
            Debug.DrawLine(ray.origin, hit.Position, Color.green, 1f);
        }
    }
}