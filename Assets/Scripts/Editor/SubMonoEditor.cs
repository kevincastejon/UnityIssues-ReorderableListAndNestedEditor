using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(SubMono))]
public class SubMonoEditor : Editor
{
    private SerializedProperty _strings;
    private ReorderableList _list;

    private void OnEnable()
    {
        _strings = serializedObject.FindProperty("_strings");
        _list = new ReorderableList(serializedObject, _strings);
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        //EditorGUILayout.PropertyField(_strings);  // into nested editor regular list is ok
        _list.DoLayoutList();                       // into nested editor ReorderableList items can't be selected nor dragged

        serializedObject.ApplyModifiedProperties();
    }
}
