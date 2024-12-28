using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.Mains.Runtime.References
{
    public class MainEntityReferenceSingletonComponentDataAuthoring : MonoBehaviour
    {
        public class MainEntityReferenceSingletonComponentDataBaker : Baker<MainEntityReferenceSingletonComponentDataAuthoring>
        {
            public override void Bake(MainEntityReferenceSingletonComponentDataAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<MainEntityReferenceSingletonComponentData>(entity);
            }
        }
    }
}