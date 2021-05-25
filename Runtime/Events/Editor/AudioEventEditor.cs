using UnityEngine;
using UnityEditor;
using BirdTools;

[CustomEditor(typeof(AudioEvent), true)]
public class AudioEventEditor : Editor
{
    [SerializeField] private AudioSource _previewer;

    private void OnEnable()
    {
        _previewer = EditorUtility.CreateGameObjectWithHideFlags("audio preview",
                HideFlags.HideAndDontSave, typeof(AudioSource))
            .GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        DestroyImmediate(_previewer.gameObject);
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);
        if (GUILayout.Button("preview"))
        {
            ((AudioEvent) target).Play(_previewer);
        }
        EditorGUI.EndDisabledGroup();
    }
}
