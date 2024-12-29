using BovineLabs.Core.ObjectManagement;
using Unity.Entities;
using UnityEngine;

namespace _Root.Scripts.Inputs.Runtime
{
    public abstract class AbstractScriptableModInputManger : ScriptableObject
    {
        public abstract void UpdateForMod(int index, ObjectId objectId, Entity entity);
        public abstract void ClearFormMod(ObjectId objectId);
    }
}