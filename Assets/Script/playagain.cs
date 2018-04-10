using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playagain : MonoBehaviour {
	public Gamecontroller gamecont;
	// Use this for initialization
	void Start () {
		
	}
	public void onclickreplaybtn(){
		gamecont.resetbtn();
	}
	// Update is called once per frame
	void Update () {
		
	}
}
