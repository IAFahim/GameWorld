using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.Healths.Runtime
{
    public class HealthAuthoring : MonoBehaviour
    {
        public float currentHealth = 1;
        public float maxHealth = 1;

        private class HealthComponentDataAuthoringBaker : Baker<HealthAuthoring>
        {
            public override void Bake(HealthAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity,
                    new HealthComponentData
                    {
                        CurrentHealth = authoring.currentHealth,
                        MaxHealth = authoring.maxHealth
                    }
                );
            }
        }
    }
}