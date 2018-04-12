using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ver2_btnscript : MonoBehaviour {
	Image Img ;
	public Sprite sprit;
	private GameObject childobj;
	public Button thisbtn;
	public Gamecontroller gamecont;
	public int btnid = -1;

	void Start () {
		Img = this.GetComponent<Image> ();
	}

	public void SetValue(int j){
		//Debug.Log ("SetValue : " + j);
		btnid = j;
	}

	public void OnclickBtn(){
		if (gamecont.turn == 3) {
			return;
		}
		//print ("Button Clicked");
		Img.sprite = sprit;
			Transform child = this.transform.GetChild (0);
			if (child.tag == "object") {
				child.gameObject.SetActive (true);
			}

		thisbtn.interactable = false;
		//Debug.Log ("SetValue1 : " + btnid);
		gamecont.DataMatch (btnid);
	}




}
