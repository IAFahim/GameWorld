using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.Physics.Runtime.Movements
{
    public class MoveSpeedComponentDataAuthoring : MonoBehaviour
    {
        public float moveSpeed;

        public class MoveSpeedComponentDataBaker : Baker<MoveSpeedComponentDataAuthoring>
        {
            public override void Bake(MoveSpeedComponentDataAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new MoveSpeedComponentData { MoveSpeed = authoring.moveSpeed });
            }
        }
    }
}