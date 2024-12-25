using _Root.Scripts.Data.Runtime;
using BovineLabs.Core.ObjectManagement;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.Mains.Runtime
{
    public class MainEntityMangerHybrid : MonoBehaviour
    {
        public Entity mainEntity;

        private void Update()
        {
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var query = entityManager.CreateEntityQuery(typeof(MainTagComponentData), typeof(ObjectId));
            var entities = query.ToEntityArray(Allocator.TempJob);
            if (entities.Length > 0)
            {
                mainEntity = entities[0];
                TestDirectionChange(ref entityManager, ref mainEntity);
            }

            entities.Dispose();
        }
        
        public void TestDirectionChange(ref EntityManager entityManager, ref Entity entity)
        {
            if (entityManager.HasComponent<DirectionComponentData>(entity))
            {
                var direction = entityManager.GetComponentData<DirectionComponentData>(entity);
                direction.Direction = new Vector3(1, 0, 0);
                entityManager.SetComponentData(entity, direction);   
            }
        }
    }
}