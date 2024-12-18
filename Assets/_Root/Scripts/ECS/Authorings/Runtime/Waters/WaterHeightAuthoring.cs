using _Root.Scripts.Data.Runtime.Waters;
using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.ECS.Authorings.Runtime.Waters
{
    public class WaterHeightAuthoring : MonoBehaviour
    {
        public int waterHeight;

        public class WaterHeightComponentDataBaker : Baker<WaterHeightAuthoring>
        {
            public override void Bake(WaterHeightAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new WaterHeightComponentData { WaterHeight = authoring.waterHeight });
            }
        }
    }
}