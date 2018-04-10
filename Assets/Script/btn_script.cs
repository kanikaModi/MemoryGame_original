using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class btn_script : MonoBehaviour {

	public Button btn;
	public Text btntext;
	public int Value_assigned;
	public int ID;
	private NewGameController GameCont;
	//public GameObject gamecontroller;
	// Use this for initialization
	void Start () {
		GameCont = GameObject.FindGameObjectWithTag ("GameController").GetComponent<NewGameController> ();
		//print ("GameCont : " + GameCont.clickturn);
	}

	public void SetTextValue(int unique, int labelVal)
	{
		Value_assigned = labelVal;
		ID = unique;
	}

	public void OnclickBtn(){
		print ("Button Clicked");
		btntext.text = Value_assigned.ToString ();
		GameCont.DataMatch (ID, Value_assigned);
		/*if (GameCont.clickturn == 0) {
			btntext.text = Value_assigned.ToString ();
			//GameCont.clickturn = 1;
			GameCont.DataMatch (ID, Value_assigned);
		} else {
			btntext.text = Value_assigned.ToString ();
			//GameCont.clickturn = 0;
			GameCont.DataMatch (ID, Value_assigned);
		}//btn.Text = Value_assigned.ToString ();
		*/
		btn.interactable = false;
		//btn.interactable = true;
		//gamecontroller.check (Value_assigned);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
