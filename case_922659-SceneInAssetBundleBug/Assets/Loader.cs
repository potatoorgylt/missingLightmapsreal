using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    var bundle = AssetBundle.LoadFromFile(string.Format("{0}/{1}", Application.streamingAssetsPath, "test"));
	    var scene = bundle.GetAllScenePaths()[0];
        SceneManager.LoadScene(scene);
	}
	
}
