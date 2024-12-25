using _Root.Scripts.Data.Runtime.Physics;
using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.Physics.Runtime.Rotates
{
    public class RotateDampingAndStrengthAuthoring : MonoBehaviour
    {
        public float damping = 0.1f;
        public float strength = 1f;
        public float accuracy = 1;

        public class RotateDampingStrengthBaker : Baker<RotateDampingAndStrengthAuthoring>
        {
            public override void Bake(RotateDampingAndStrengthAuthoring rotateDampingAndStrengthAuthoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity,
                    new RotateDampingAndStrengthComponentData
                    {
                        Damping = rotateDampingAndStrengthAuthoring.damping,
                        Strength = rotateDampingAndStrengthAuthoring.strength,
                        Accuracy = rotateDampingAndStrengthAuthoring.accuracy
                    });
            }
        }
    }
}