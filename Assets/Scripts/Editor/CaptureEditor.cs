using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

[CustomEditor(typeof(Capture))]
public class CaptureEditor : Editor
{

    public override void OnInspectorGUI()
    {
        Capture basescript = (Capture)target;

        DrawDefaultInspector();

        EditorGUILayout.Space();

        if (GUILayout.Button("Save Tex2D"))
        {
            basescript.GetRTPixels();
            basescript.SaveLastConvertedTexture();
        }
    }


}
