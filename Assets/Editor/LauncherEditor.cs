using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Launcher))]
public class LauncherEditor : Editor {

    private SerializedProperty ballPrefab;
    private SerializedProperty ballTypes;
    private SerializedProperty maxLaunchSpeed;
    private SerializedProperty maxLaunchRadius;

    private void OnEnable() {
        ballPrefab = serializedObject.FindProperty("ballPrefab");
        ballTypes = serializedObject.FindProperty("ballTypes");
        maxLaunchSpeed = serializedObject.FindProperty("maxLaunchSpeed");
        maxLaunchRadius = serializedObject.FindProperty("maxLaunchRadiusPercent");
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();

        EditorGUILayout.PropertyField(ballPrefab);
        EditorGUILayout.PropertyField(maxLaunchSpeed);
        maxLaunchRadius.floatValue = EditorGUILayout.Slider(maxLaunchRadius.floatValue, 0f, 1f);
        
        // Ball types
        if (GUILayout.Button("Add ball")) {
            ballTypes.InsertArrayElementAtIndex(ballTypes.arraySize);
        }

        for (int i = ballTypes.arraySize - 1; i >= 0; i--) {
            GUILayout.BeginHorizontal();
            { 
                EditorGUILayout.PropertyField(ballTypes.GetArrayElementAtIndex(i), new GUIContent("Ball " + (i + 1)));

                // delete button
                if (GUILayout.Button("X", GUILayout.MaxWidth(30f))) {
                    ballTypes.DeleteArrayElementAtIndex(i);
                }
            }
            GUILayout.EndHorizontal();
        }

        serializedObject.ApplyModifiedProperties();
    }

}
