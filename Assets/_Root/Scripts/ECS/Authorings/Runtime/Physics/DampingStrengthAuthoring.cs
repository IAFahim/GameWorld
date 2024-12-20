using _Root.Scripts.Data.Runtime.Physics;
using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.ECS.Authorings.Runtime.Physics
{
    public class DampingStrengthAuthoring : MonoBehaviour
    {
        public float damping = 0.1f;
        public float strength = 1;

        public class DampingStrengthDataBaker : Baker<DampingStrengthAuthoring>
        {
            public override void Bake(DampingStrengthAuthoring strengthAuthoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity,
                    new DampingStrengthComponentData { Damping = strengthAuthoring.damping, Strength = strengthAuthoring.strength });
            }
        }
    }
}