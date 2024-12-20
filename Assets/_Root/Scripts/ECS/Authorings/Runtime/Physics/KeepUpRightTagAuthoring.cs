using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.Data.Runtime.Physics
{
    public class KeepUpRightTagAuthoring : MonoBehaviour
    {
        public class KeepUpRightTagComponentDataBaker : Baker<KeepUpRightTagAuthoring>
        {
            public override void Bake(KeepUpRightTagAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<KeepUpRightTagComponentData>(entity);
            }
        }
    }
}