using UnityEditor;

[CustomEditor(typeof(MainMono))]
public class MainMonoEditor : Editor
{
    private SerializedProperty _subMono;

    private void OnEnable()
    {
        _subMono = serializedObject.FindProperty("_subMono");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(_subMono);

        if (_subMono.objectReferenceValue != null)
        {
            CreateEditor(_subMono.objectReferenceValue).OnInspectorGUI();
        }

        serializedObject.ApplyModifiedProperties();
    }
}
