using System.Reflection;
using UnityEditor;
using UnityEngine;

public class NestedEditorProperty
{
    private SerializedProperty _property;
    private Editor _editor;

    public NestedEditorProperty(SerializedProperty prop)
    {
        _property = prop;
        if (prop.objectReferenceValue)
        {
            _editor = Editor.CreateEditor(prop.objectReferenceValue);
        }
    }

    public SerializedProperty Property { get => _property; }
    public Object ObjectReferenceValue { get => _property.objectReferenceValue; }
public void OnInspectorGUI()
    {
        if (_editor == null || _editor.target != _property.objectReferenceValue)
        {
            _editor = Editor.CreateEditor(_property.objectReferenceValue);
        }
        _editor.OnInspectorGUI();
    }
    public void OnDisable()
    {
        MethodInfo disableMethod = _editor.GetType().GetMethod("OnDisable", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        if (disableMethod != null)
        {
            disableMethod.Invoke(_editor, null);
        }
        UnityEngine.Object.DestroyImmediate(_editor);
    }
    public void LayoutReferenceField()
    {
        EditorGUILayout.PropertyField(_property);
    }
    public void ReferenceField(Rect rect)
    {
        EditorGUI.PropertyField(rect, _property);
    }
}