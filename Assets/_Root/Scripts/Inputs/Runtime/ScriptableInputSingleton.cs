using BovineLabs.Core.ObjectManagement;
using Pancake;
using Sirenix.OdinInspector;
using Unity.Entities;
using UnityEditor;
using UnityEngine;

namespace _Root.Scripts.Inputs.Runtime
{
    [CreateAssetMenu(fileName = "ScriptableInputSingleton", menuName = "Scriptable/Input/MainSingleton", order = 100)]
    public class ScriptableInputSingleton : ScriptableSettings<ScriptableInputSingleton>
    {
        private static ObjectId DefaultObjectId => new(int.MinValue, int.MinValue);

        [SerializeField] private AbstractScriptableModInputManger[] scriptableModInputMangers;

        [ShowInInspector, ReadOnly] private ObjectId _currentId = DefaultObjectId;
        [ShowInInspector, ReadOnly] private bool _live;

        public void UpdateForMod(ObjectId objectId, Entity entity)
        {
            if (_live)
            {
                if (_currentId != objectId)
                {
                    ClearFromMod(objectId);
                    _currentId = objectId;
                }
            }
            else
            {
                _currentId = objectId;
                _live = true;
            }
            int modIndex = objectId.Mod >> 1;
            if (modIndex >= scriptableModInputMangers.Length) return;
            scriptableModInputMangers[modIndex].UpdateForMod(modIndex,_currentId, entity);
        }

        public void ClearFromMod(ObjectId objectId)
        {
            int modIndex = objectId.Mod >> 1;
            if (modIndex >= scriptableModInputMangers.Length) return;
            scriptableModInputMangers[modIndex].ClearFormMod(_currentId);
        }

        private void OnEnable()
        {
#if UNITY_EDITOR
            EditorApplication.playModeStateChanged += EditorApplicationOnplayModeStateChanged;
#endif
        }

#if UNITY_EDITOR
        private void EditorApplicationOnplayModeStateChanged(PlayModeStateChange obj)
        {
            if (obj == PlayModeStateChange.ExitingPlayMode)
            {
                if (_live && _currentId != DefaultObjectId) ClearFromMod(_currentId);
                _live = false;
                _currentId = DefaultObjectId;
            }
        }
#endif

        private void OnDisable()
        {
#if UNITY_EDITOR
            EditorApplication.playModeStateChanged -= EditorApplicationOnplayModeStateChanged;
#endif
        }
    }
}