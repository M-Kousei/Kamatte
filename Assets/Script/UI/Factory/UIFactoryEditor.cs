#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using Kamatte.UI.Factory;

namespace Kamatte.UI.Editors
{
    [CustomEditor(typeof(UIFactory))]
    public class UIFactoryEditor : Editor
    {
        private ReorderableList list;

        private void OnEnable()
        {
            var mappingsProp = serializedObject.FindProperty("uiMappings");

            list = new ReorderableList(serializedObject, mappingsProp, true, true, true, true);
            list.drawElementCallback = (rect, index, isActive, isFocused) =>
            {
                var element = mappingsProp.GetArrayElementAtIndex(index);
                EditorGUI.PropertyField(
                    new Rect(rect.x, rect.y, rect.width / 2, EditorGUIUtility.singleLineHeight),
                    element.FindPropertyRelative("buttonControllerID"), GUIContent.none);

                EditorGUI.PropertyField(
                    new Rect(rect.x + rect.width / 2, rect.y, rect.width / 2, EditorGUIUtility.singleLineHeight),
                    element.FindPropertyRelative("uiPrefab"), GUIContent.none);
            };

            list.drawHeaderCallback = (rect) =>
            {
                EditorGUI.LabelField(rect, "UI Mappings (ButtonControllerID Å® Prefab)");
            };
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            list.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif