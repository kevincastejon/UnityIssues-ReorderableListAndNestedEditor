using UnityEditor;
[CustomEditor(typeof(MainObject))]
public class MainObjectEditor : Editor
{
    NestedEditorProperty _sub;
    private void OnEnable()
    {
        _sub = new NestedEditorProperty(serializedObject.FindProperty("_subMono"));
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        _sub.LayoutReferenceField();
        if (_sub.ObjectReferenceValue != null)
        {
            _sub.OnInspectorGUI();
        }
        serializedObject.ApplyModifiedProperties();
    }
    private void OnDisable()
    {
        _sub.OnInspectorGUI();
    }
}
