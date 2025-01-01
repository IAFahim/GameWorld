using BovineLabs.Core.ObjectManagement;
using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.AttractionAndAvoidances.Runtime
{
    public class AttractionAndAvoidanceComponentDataAuthoring : MonoBehaviour
    {
        public int MainEntityPriority;
        [ObjectCategories] public int Mod1;
        [ObjectCategories] public int Mod2;
        [ObjectCategories] public int Mod3;

        public class AttractionAndAvoidanceComponentDataBaker : Baker<AttractionAndAvoidanceComponentDataAuthoring>
        {
            public override void Bake(AttractionAndAvoidanceComponentDataAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity,
                    new AttractionAndAvoidanceComponentData
                    {
                        MainEntityPriority = authoring.MainEntityPriority,
                        Mod1 = authoring.Mod1,
                        Mod2 = authoring.Mod2,
                        Mod3 = authoring.Mod3
                    });
            }
        }
    }
}