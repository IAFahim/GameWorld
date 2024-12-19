using _Root.Scripts.Data.Runtime.Stats;
using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.ECS.Authorings.Runtime.Stats
{
    public class LevelAuthoring : MonoBehaviour
    {
        public int level;

        public class LevelComponentDataBaker : Baker<LevelAuthoring>
        {
            public override void Bake(LevelAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new LevelComponentData
                {
                    CurrentLevel = authoring.level
                });
            }
        }
    }
}