using Nstdspace.Commons;
using UnityEditor;
using UnityEngine;

namespace Nstdspace.Commons.Editor {
    [CustomPropertyDrawer(typeof(InspectorReadOnlyAttribute))]
    public class InspectorReadOnlyDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            var isEnabled = GUI.enabled;

            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label);

            GUI.enabled = isEnabled;
        }
    }
}