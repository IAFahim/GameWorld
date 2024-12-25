using _Root.Scripts.ManagedReferenceProviders.Runtime;
using Sirenix.OdinInspector;
using Unity.Burst;
using Unity.Entities;
using Unity.Physics;
using Unity.Physics.Authoring;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Ray = UnityEngine.Ray;
using RaycastHit = Unity.Physics.RaycastHit;

namespace _Root.Scripts.Hybrids.Selects.Runtime.Selects
{
    public class ForSelectedManagedReferenceProviderMonoBehaviour : MonoBehaviour
    {
        // public PhysicsCategoryTags belongsTo;
        // public PhysicsCategoryTags collidesWith;
        // public int groupIndex = 0;
        // public float maxDistance = 100f;
        //
        // private CollisionFilter _collisionFilter;
        //
        //
        // protected void Update()
        // {
        //     var mainCamera = MainCameraReferenceProvider.Instance;
        //     if (MainEventSystemReferenceProvider.Instance.IsPointerOverGameObject()) return;
        //     if (Mouse.current != null)
        //     {
        //         var leftButtonPressed = Mouse.current.leftButton.isPressed;
        //         if (leftButtonPressed) ProcessClick(mainCamera, Mouse.current.position.ReadValue());
        //     }
        //     else if (Touchscreen.current != null)
        //     {
        //         var touch = Touchscreen.current.primaryTouch;
        //         if (touch.press.isPressed) ProcessClick(touch.position.ReadValue());
        //     }
        // }
        //
        // private void ProcessClick(Camera mainCamera, Vector2 readValue)
        // {
        //     var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        //     var collisionWorld = entityManager.CreateEntityQuery(typeof(PhysicsWorldSingleton))
        //         .GetSingleton<PhysicsWorldSingleton>()
        //         .PhysicsWorld.CollisionWorld;
        //     
        //     Ray ray = mainCamera.ScreenPointToRay(readValue);
        //     var collisionFilter = new CollisionFilter
        //     {
        //         BelongsTo = belongsTo.Value,
        //         CollidesWith = collidesWith.Value,
        //         GroupIndex = groupIndex
        //     };
        //     PerformRayCast(ref entityManager, ref collisionWorld, ref ray, ref collisionFilter);
        // }
        //
        // [BurstCompile]
        // private void PerformRayCast(
        //     ref EntityManager entityManager, ref CollisionWorld collisionWorld,
        //     ref Ray ray, ref CollisionFilter collisionFilter
        // )
        // {
        //     if (collisionWorld.CastRay(new RaycastInput
        //         {
        //             Start = ray.origin,
        //             End = ray.origin + ray.direction * maxDistance,
        //             Filter = collisionFilter
        //         }, out var hit))
        //     {
        //         ForgetSelectedComponent(ref entityManager, ray);
        //         SetSelectedComponent(ref collisionWorld, ref entityManager, hit, ray);
        //     }
        //     else
        //     {
        //         if (_selectedComponentData.UnFocusEmptyClicked) ForgetSelectedComponent(ref entityManager, ray);
        //     }
        // }
        //
        // private void ForgetSelectedComponent(ref EntityManager entityManager, Ray ray)
        // {
        //     if (_selectedEntity != Entity.Null && entityManager.Exists(_selectedEntity))
        //     {
        //         entityManager.SetComponentEnabled<SelectedComponentData>(_selectedEntity, false);
        //         _selectedEntity = Entity.Null;
        //         Debug.DrawLine(ray.origin, ray.origin + ray.direction * maxDistance, Color.red, 1f);
        //     }
        //     else
        //     {
        //         Debug.DrawLine(ray.origin, ray.origin + ray.direction * maxDistance, Color.blue, 1f);
        //     }
        // }
        //
        // private void SetSelectedComponent(
        //     ref CollisionWorld collisionWorld, ref EntityManager entityManager,
        //     RaycastHit hit, Ray ray
        // )
        // {
        //     _selectedEntity = collisionWorld.Bodies[hit.RigidBodyIndex].Entity;
        //     if (!entityManager.HasComponent<SelectedComponentData>(_selectedEntity)) return;
        //     _selectedComponentData = entityManager.GetComponentData<SelectedComponentData>(_selectedEntity);
        //     entityManager.SetComponentEnabled<SelectedComponentData>(_selectedEntity, true);
        //     entityManager.SetComponentData(_selectedEntity, new SelectedComponentData()
        //     {
        //         UnFocusEmptyClicked = _selectedComponentData.UnFocusEmptyClicked,
        //         TimeSceneEnabled = 0
        //     });
        //     Debug.DrawLine(ray.origin, hit.Position, Color.green, 1f);
        // }
    }
}