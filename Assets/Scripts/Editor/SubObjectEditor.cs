using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(SubObject))]
public class SubObjectEditor : Editor
{
    private SerializedProperty _strings;
    private ReorderableList _list;

    public void OnEnable()
    {
        Debug.Log("OnEnable");
        _strings = serializedObject.FindProperty("_strings");
        _list = new ReorderableList(serializedObject, _strings);
    }
    public override void OnInspectorGUI()
    {
        Debug.Log("OnInspectorGUI");
        serializedObject.Update();
        //EditorGUILayout.PropertyField(_strings);  // into nested editor regular list is ok
        _list.DoLayoutList();                       // into nested editor ReorderableList items can't be selected nor dragged
        serializedObject.ApplyModifiedProperties();
    }
}