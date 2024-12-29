using Pancake;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Root.Scripts.Mains.Runtime.References
{
    [CreateAssetMenu(fileName = "ScriptableMainReferenceMiddlewareSingleton",
        menuName = "Scriptable/MainReferenceMiddlewareSingleton", order = 256)]
    public class
        ScriptableMainReferenceMiddlewareSingleton : ScriptableSettings<ScriptableMainReferenceMiddlewareSingleton>
    {
        [FormerlySerializedAs("scriptableMainRefernceProcessor")] [FormerlySerializedAs("scriptableModInputMangers")] [SerializeField]
        private AbstractScriptableMainReferenceProcessor[] scriptableMainReferenceProcessor;

        [ShowInInspector, ReadOnly] private bool _live;

        public void Process(MainEntityReferenceSingletonComponentData mainEntityReference)
        {
            bool changedThisFrame = mainEntityReference.IsChangedThisFrame;
            if (changedThisFrame)
            {
                _live = true;
                DisableActive();
            }

            if (mainEntityReference.IsPresent)
            {
                int modIndex = mainEntityReference.Mod;
                int index = 0;
                while (modIndex > 0)
                {
                    if((modIndex & 1) == 0) continue;
                    if (index > scriptableMainReferenceProcessor.Length) break;
                    if (changedThisFrame)
                    {
                        scriptableMainReferenceProcessor[index].Set(mainEntityReference);
                        scriptableMainReferenceProcessor[index].isModActive = true;
                    }
                    scriptableMainReferenceProcessor[index].Tick(mainEntityReference);
                    modIndex >>= 1;
                    index++;
                }
            }
        }

        private void DisableActive()
        {
            foreach (var scriptableModInputManger in scriptableMainReferenceProcessor)
            {
                if (scriptableModInputManger.isModActive)
                {
                    scriptableModInputManger.Forget();
                    scriptableModInputManger.isModActive = false;
                }
            }
        }

        private void OnEnable()
        {
#if UNITY_EDITOR
            EditorApplication.playModeStateChanged -= EditorApplicationOnplayModeStateChanged;
            EditorApplication.playModeStateChanged += EditorApplicationOnplayModeStateChanged;
#endif
        }

#if UNITY_EDITOR
        private void EditorApplicationOnplayModeStateChanged(PlayModeStateChange obj)
        {
            if (obj == PlayModeStateChange.ExitingPlayMode)
            {
                if (_live) DisableActive();
                _live = false;
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