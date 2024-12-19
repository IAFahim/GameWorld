using _Root.Scripts.Data.Runtime;
using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.ECS.Authorings.Runtime
{
    public class DeathTimerAuthoring : MonoBehaviour
    {
        public float remainingAliveTime = 5;

        public class DeathTimerBaker : Baker<DeathTimerAuthoring>
        {
            public override void Bake(DeathTimerAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new DeathTimerComponentData
                {
                    RemainingAliveTime = authoring.remainingAliveTime
                });
            }
        }
    }
}