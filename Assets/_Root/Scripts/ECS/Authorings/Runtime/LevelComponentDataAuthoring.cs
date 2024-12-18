using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.ECS.Levels.Runtime
{
    public class LevelComponentDataAuthoring : MonoBehaviour
    {
        public int level;

        public class LevelComponentDataBaker : Baker<LevelComponentDataAuthoring>
        {
            public override void Bake(LevelComponentDataAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new LevelComponentData { Level = authoring.level });
            }
        }
    }
}