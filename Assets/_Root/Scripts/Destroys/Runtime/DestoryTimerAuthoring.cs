using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.Destroys.Runtime
{
    public class DestoryTimerAuthoring : MonoBehaviour
    {
        public float remainingAliveTime = 5;

        public class DeathTimerBaker : Baker<DestoryTimerAuthoring>
        {
            public override void Bake(DestoryTimerAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new DestroyTimerComponentData
                {
                    RemainingAliveTime = authoring.remainingAliveTime
                });
            }
        }
    }
}