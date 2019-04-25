using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

[CustomEditor(typeof(CompareTex2D))]
public class CompareTex2DEditor : Editor
{

    public override void OnInspectorGUI()
    {
        CompareTex2D basescript = (CompareTex2D)target;

        DrawDefaultInspector();

        EditorGUILayout.Space();

        if (GUILayout.Button("Compare"))
        {
            basescript.Compare();
        }
    }

}
