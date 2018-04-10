using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playscr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void onclickbtn(){
		SceneManager.LoadScene ("scene_ver6");
	}

	public void onclickhome(){
		SceneManager.LoadScene ("front_scene_ver1");
	}

	public void onclickexit(){
		Application.Quit();
	}
	// Update is called once per frame
	void Update () {
		
	}
}
