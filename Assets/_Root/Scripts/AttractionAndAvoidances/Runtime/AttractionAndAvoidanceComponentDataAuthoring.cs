using Unity.Entities;
using Unity.Physics.Authoring;
using UnityEngine;

namespace _Root.Scripts.AttractionAndAvoidances.Runtime
{
    public class AttractionAndAvoidanceComponentDataAuthoring : MonoBehaviour
    {
        [SerializeField] private PhysicsCategoryTags physicsCategoryTagAdd1;
        [SerializeField] private PhysicsCategoryTags physicsCategoryTagAdd2;
        [SerializeField] short mainEntityPriority;

        public class AttractionAndAvoidanceComponentDataBaker : Baker<AttractionAndAvoidanceComponentDataAuthoring>
        {
            public override void Bake(AttractionAndAvoidanceComponentDataAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity,
                    new AttractionAndAvoidanceComponentData
                    {
                        PhysicsCategoryTagAdd1 = authoring.physicsCategoryTagAdd1.Value,
                        PhysicsCategoryTagAdd2 = authoring.physicsCategoryTagAdd2.Value,
                        MainEntityPriority = authoring.mainEntityPriority,
                    });
            }
        }
    }
}