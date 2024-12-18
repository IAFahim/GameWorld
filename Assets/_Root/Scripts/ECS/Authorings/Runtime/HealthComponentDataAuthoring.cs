using _Root.Scripts.Data.Runtime;
using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.ECS.Authorings.Runtime
{
    public class HealthComponentDataAuthoring : MonoBehaviour
    {
        public float health = 1;
        public float maxHealth = 1;

        private class HealthComponentDataAuthoringBaker : Baker<HealthComponentDataAuthoring>
        {
            public override void Bake(HealthComponentDataAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity,
                    new HealthComponentData
                    {
                        Health = authoring.health,
                        MaxHealth = authoring.maxHealth
                    }
                );
            }
        }
    }
}