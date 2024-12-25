using BovineLabs.Core.ObjectManagement;
using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.ObjectIDs.Runtime
{
    public class ObjectIdAuthoring : MonoBehaviour
    {
        public int mod;
        public int id;

        private class ObjectIdAuthoringBaker : Baker<ObjectIdAuthoring>
        {
            public override void Bake(ObjectIdAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity,
                    new ObjectId(authoring.mod, authoring.id)
                );
            }
        }
    }
}