using _Root.Scripts.Data.Runtime;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace _Root.Scripts.Directions.Runtime
{
    public class DirectionAuthoring : MonoBehaviour
    {
        public float3 direction;

        public class DirectionComponentDataBaker : Baker<DirectionAuthoring>
        {
            public override void Bake(DirectionAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new DirectionComponentData
                {
                    Direction = authoring.direction
                });
            }
        }
    }
}