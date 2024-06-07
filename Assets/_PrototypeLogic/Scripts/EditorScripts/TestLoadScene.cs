using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;


public class TestLoadScene
{
	[MenuItem("SetDefaultScene/First")]
	public static void Play()
	{
		var pathFirstScene = EditorBuildSettings.scenes[0].path;
		var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(pathFirstScene);
		EditorSceneManager.playModeStartScene = sceneAsset;
	}

	[MenuItem("OpenScene/First")]
	public static void OpenF()
	{
		var pathFirstScene = EditorBuildSettings.scenes[0].path;
		EditorSceneManager.SaveScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene());
		EditorSceneManager.OpenScene(pathFirstScene);
	}
	[MenuItem("OpenScene/Second")]
	public static void OpenS()
	{
		var pathFirstScene = EditorBuildSettings.scenes[1].path;
		EditorSceneManager.SaveScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene());
		EditorSceneManager.OpenScene(pathFirstScene);
	}


}
