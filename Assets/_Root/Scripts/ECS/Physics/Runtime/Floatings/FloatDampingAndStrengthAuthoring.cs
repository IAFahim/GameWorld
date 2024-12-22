using _Root.Scripts.Data.Runtime.Physics;
using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.ECS.Physics.Runtime.Floatings
{
    public class FloatDampingAndStrengthAuthoring : MonoBehaviour
    {
        public float damping = 0.1f;
        public float strength = 1;

        public class FloatDampingAndStrengthDataBaker : Baker<FloatDampingAndStrengthAuthoring>
        {
            public override void Bake(FloatDampingAndStrengthAuthoring floatDampingAndStrengthAuthoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity,
                    new FloatDampingAndStrengthComponentData
                    {
                        Damping = floatDampingAndStrengthAuthoring.damping,
                        Strength = floatDampingAndStrengthAuthoring.strength
                    }
                );
            }
        }
    }
}