using _Root.Scripts.Data.Runtime.Deaths;
using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.ECS.Authorings.Runtime.Deaths
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