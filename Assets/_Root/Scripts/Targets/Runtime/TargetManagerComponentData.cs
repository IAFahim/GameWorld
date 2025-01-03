using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.Targets.Runtime
{
    public struct TargetManagerComponentData : IComponentData
    {
        public ETarget Target;
        public Entity TargetEntity;
    }

    public class TargetManagerComponentDataAuthoring : MonoBehaviour
    {
        public ETarget target;
        public Entity targetEntity;

        public class TargetManagerComponentDataBaker : Baker<TargetManagerComponentDataAuthoring>
        {
            public override void Bake(TargetManagerComponentDataAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new TargetManagerComponentData
                {
                    Target = authoring.target,
                    TargetEntity = authoring.targetEntity
                });
            }
        }
    }
}