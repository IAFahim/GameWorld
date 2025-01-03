﻿using _Root.Scripts.Tags.Runtime.Waters;
using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.Waters.Runtime
{
    public class OnWaterTagAuthoring : MonoBehaviour
    {
        public class OnWaterTagComponentDataBaker : Baker<OnWaterTagAuthoring>
        {
            public override void Bake(OnWaterTagAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<OnWaterTagComponentData>(entity);
            }
        }
    }
}