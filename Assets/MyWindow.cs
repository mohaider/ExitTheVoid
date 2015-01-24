using UnityEngine;
using UnityEditor;
using System.Collections;

public class MyWindow : EditorWindow
{
    string myString = "Hello world";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;
    

    //Add menu item named "Nilan Properties" to the Window Menu

    [MenuItem("Window/Player/Nilan Properties")]

    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, create one.
        EditorWindow.GetWindow(typeof(MyWindow));
    }
    void OnGUI()
    {

        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField("Text Field", myString);

        groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        myBool = EditorGUILayout.Toggle("Toggle", myBool);
        myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
        EditorGUILayout.EndToggleGroup();
    }
}
