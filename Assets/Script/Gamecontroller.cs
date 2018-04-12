using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// for TextPro text
using TMPro;


public class Gamecontroller : MonoBehaviour {
	int slot_length;
	public Button[] buttonList;
	private int[] slotnum;
	//List<string> list_obj;
	public GameObject[] prefab_obj;
	public int turn = 1; 
	private int prev_btnclick = -1;// value 1 or 2
	private int curr_btnclick = -1;
	private int total_score = 0;
	public TextMeshPro score;
	public TextMeshPro Timetext;
	public Sprite redsprit;
	public GameObject gameover;
	private float timer;
	private int gamestatus;//Dictionary<string, int> obj_veg;
	//Dictionary<int, string> obj_veg1;
	// Use this for initialization
	public audiomanager audiomng;
	void Start () {
		//Debug.Log ("WHY YOU COME HERE");
		gamestatus = 1;
		slot_length = buttonList.Length;

		slotnum = new int[slot_length];
		int nextnum = 0;
		for(int i=0; i < slot_length/2; i++)
		{
			slotnum [2 * i] = nextnum;
			slotnum [2 * i + 1] = nextnum;
			nextnum = nextnum + 1;
		}

		for (int j = slot_length - 1; j > -1; j--) {
			int num = Mathf.RoundToInt (UnityEngine.Random.Range (0, j - 1));
			int temp = slotnum[j];
			slotnum[j] = slotnum[num];
			slotnum[num] = temp;
		}

		for(int j = 0; j < slot_length; j++)
		{
			int num = slotnum[j];
			prefab_obj [num].SetActive (false);
			Instantiate (prefab_obj [num], buttonList [j].transform);
			Debug.Log ("j : " + j);
			buttonList[j].GetComponent<ver2_btnscript>().SetValue(j);
		}
	}

	public void resetbtn(){
		
		total_score = 0;
		turn = 1;
		prev_btnclick = -1;
		curr_btnclick = -1;
		timer = 0;
		gameover.SetActive (false);
		slot_length = buttonList.Length;

		slotnum = new int[slot_length];
		int nextnum = 0;
		for(int i=0; i < slot_length/2; i++)
		{
			slotnum [2 * i] = nextnum;
			slotnum [2 * i + 1] = nextnum;
			nextnum = nextnum + 1;
		}

		for (int j = slot_length - 1; j > -1; j--) {
			int num = Mathf.RoundToInt (UnityEngine.Random.Range (0, j - 1));
			int temp = slotnum[j];
			slotnum[j] = slotnum[num];
			slotnum[num] = temp;
		}

		for(int j = 0; j < slot_length; j++)
		{
			int num = slotnum[j];
			// Destroy the old prefab veg attached to the button
			GameObject oob = buttonList [j].transform.GetChild(0).gameObject;
			Destroy (oob);

			// Reset the button image to red one
			Image Img = buttonList[j].GetComponent<Image> ();
			Img.sprite = redsprit;

			buttonList [j].interactable = true;

			prefab_obj [num].SetActive (false);
			Instantiate (prefab_obj [num], buttonList [j].transform);
			//buttonList[j].GetComponent<ver2_btnscript>().SetValue(j);
		}
		gamestatus = 1;
	}

	private void check_gameover()
	{
		Debug.Log("total_score" + total_score);
		if(total_score == buttonList.Length)
		{
			Debug.Log ("INSIDE ");
			//GameObject gameover = GameObject.FindGameObjectWithTag ("gameover");
			Invoke("gameover2", 2f);
			//gameover.SetActive (true);
			gamestatus = 0;
		}
	}

	private void gameover2(){
		audiomng.Play ("win");
		gameover.SetActive (true);
	}

	public void DataMatch(int btnid)
	{
		
		if (turn == 1) {
			turn = 2;
			prev_btnclick = btnid;
			//prev_btnclick = -1;
		} else if (turn == 2) {
			turn = 3;
			Debug.Log ("Second click" + prev_btnclick + "  " + btnid);
			if(slotnum[prev_btnclick] == slotnum[btnid])
			{
				audiomng.Play ("correct");
				total_score = total_score + 2;
				score.SetText ("Score {0}", total_score);
				//print ("total_score" + total_score);
				check_gameover ();
				prev_btnclick = -1;
			}
			else{
				audiomng.Play ("wrong");
				curr_btnclick = btnid;
				StartCoroutine (resetthebutton());

			}
			turn = 1;
		}

	}

	IEnumerator resetthebutton(){
		yield return new WaitForSeconds (0.5f);
		Debug.Log ("btn id " + prev_btnclick + " " + curr_btnclick);
		Transform child = buttonList [prev_btnclick].transform.GetChild (0);
		if (child.tag == "object") {
			child.gameObject.SetActive (false);
		}
		Image Img = buttonList[prev_btnclick].GetComponent<Image> ();
		Img.sprite = redsprit;
		buttonList [prev_btnclick].interactable = true;

		child = buttonList [curr_btnclick].transform.GetChild (0);
		if (child.tag == "object") {
			child.gameObject.SetActive (false);
		}
		Img = buttonList [curr_btnclick].GetComponent<Image> ();
		Img.sprite = redsprit;
		buttonList [curr_btnclick].interactable = true;
		prev_btnclick = -1;
	}

	void Update(){
		if (gamestatus == 1) {
			timer = timer + Time.deltaTime;
			float min = Mathf.Floor (timer / 60);
			float sec = Mathf.RoundToInt (timer % 60);
			string mm;
			string ss;
			if (min < 10) {
				mm = "0" + min.ToString ();
			} else {
				mm = min.ToString ();
			}

			if (sec < 10) {
				ss = "0" + sec.ToString ();
			} else {
				ss = sec.ToString ();
			}
			Timetext.SetText ("Time " + mm + ":" + ss);
		}
	}
}
	// Update is called once per frame

		/*list_obj.Add("broccoli");
		list_obj.Add("cabbage");
		list_obj.Add("carrot");
		list_obj.Add("cauliflower");
		list_obj.Add("corn");*/
		/*obj_veg = new Dictionary<int, string>();
		obj_veg.Add (1, "broccoli");
		obj_veg.Add (2, "cabbage");
		obj_veg.Add (3, "carrot");
		obj_veg.Add (4, "cauliflower");
		obj_veg.Add (5, "corn");
		/*obj_veg.Add ("cucumbers",6);
		obj_veg.Add ("eggplant",7);
		obj_veg.Add ("greencap",8);
		obj_veg.Add ("greenchilli",9);
		obj_veg.Add ("mushroom",10);
		obj_veg.Add ("onion",11);
		obj_veg.Add ("potato",12);
		obj_veg.Add ("pumpkin",13);
		obj_veg.Add ("redcap",14);
		obj_veg.Add ("redchilli",15);
		obj_veg.Add ("salad",16);
		obj_veg.Add ("tomato",17);
		obj_veg.Add ("yellowcap",18);*/
		/*obj_veg = new Dictionary<string, int>();
		obj_veg.Add ("broccoli",1);
		obj_veg.Add ("cabbage",2);
		obj_veg.Add ("carrot",3);
		obj_veg.Add ("cauliflower",4);
		obj_veg.Add ("corn",5);
		obj_veg.Add ("cucumbers",6);
		obj_veg.Add ("eggplant",7);
		obj_veg.Add ("greencap",8);
		obj_veg.Add ("greenchilli",9);
		obj_veg.Add ("mushroom",10);
		obj_veg.Add ("onion",11);
		obj_veg.Add ("potato",12);
		obj_veg.Add ("pumpkin",13);
		obj_veg.Add ("redcap",14);
		obj_veg.Add ("redchilli",15);
		obj_veg.Add ("salad",16);
		obj_veg.Add ("tomato",17);
		obj_veg.Add ("yellowcap",18);*/




