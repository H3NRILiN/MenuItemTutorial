using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneChanger : MonoBehaviour
{
    [MenuItem("我的工具/場景變換/Scene_Orange %#Z")]
    static void ToSceneOrange()
    {
        ChangeScene("Assets/Scenes/Scene_Orange.unity");
    }
    [MenuItem("我的工具/場景變換/Scene_Aqua %#X")]
    static void ToSceneLime()
    {
        ChangeScene("Assets/Scenes/Scene_Aqua.unity");
    }

    static void ChangeScene(string path)
    {
        LoadSceneParameters parameters = new LoadSceneParameters(LoadSceneMode.Single);
        if (Application.isPlaying)
        {
            EditorSceneManager.LoadSceneInPlayMode(path, parameters);
        }
        else
        {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            EditorSceneManager.OpenScene(path);
        }
    }
}
