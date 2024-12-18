using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.ECS.Authorings.Runtime
{
    public class HealthComponentDataAuthoring : MonoBehaviour
    {
        private class HealthComponentDataAuthoringBaker : Baker<HealthComponentDataAuthoring>
        {
            public override void Bake(HealthComponentDataAuthoring authoring)
            {
            }
        }
    }
}