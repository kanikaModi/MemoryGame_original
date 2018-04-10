using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewGameController : MonoBehaviour {

	private int[] slotnum;
	int slot_length = 0;
	public Text[] buttonList;
	public string[] playername;
	//public string player2name;
	public Text labelplayer1point;
	public Text labelplayer2point;
	public Text labelplayerturn;// whether player 1 or player2

	private int[] points;
	//private int p2_points = 0;
	private int clickturn = 0; // its value can be 1 or 2
	private int playerturn = 0; // 0
	private int curr_btn = -1;
	private int next_btn = -1;
	private int curr_val = -1;

	void Start(){
		
		points = new int[2];
		points [0] = 0;
		points [1] = 0;
		setlabel ();

		slot_length = buttonList.Length;
		//print ("slot_length : " + slot_length);

		slotnum = new int[slot_length];
		int nextnum = 1;
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
			buttonList[j].GetComponentInParent<btn_script>().SetTextValue(j, slotnum[j]);
		}
	}

	private void setlabel (){
		labelplayerturn.text = playername[playerturn] + " turn";
		labelplayer1point.text = playername[0] + " :  " + points[0].ToString();
		labelplayer2point.text = playername[1] + " :  " + points[1].ToString();
		//labelplayer2point.text = points[1].ToString();
	}

	public void DataMatch(int btnid, int btnval)
	{
		if ((points [0] + points [1]) == slot_length) {
			
		}
		if (clickturn == 0) {
			clickturn = 1;
			curr_btn = btnid;
			curr_val = btnval;
			print ("THis is first click");
		} else if (clickturn == 1) {
			//print ("THis is second click");
			next_btn = btnid;
			clickturn = 0;
			if (btnval == curr_val) {
				points [playerturn] = points [playerturn] + 2;
				print ("THis is second click - Right Click");
				set_successattempt ();
			} else {
				print ("THis is second click - wrong Click");
				labelplayerturn.text = "WRONG";
				//print ("curr_btn" + curr_btn);
				//print ("next_btn" + next_btn);

				StartCoroutine (resetthebutton());

			}
		}
	}

	IEnumerator resetthebutton(){
		yield return new WaitForSeconds(2);

		buttonList[curr_btn].text = "";
		buttonList[next_btn].text = "";	
		// Make the button retractable;
		Button b = buttonList[curr_btn].GetComponentInParent<Button>();
		b.interactable = true;
			//.interactable = true;
		//buttonList[curr_btn].GetComponentInParent<Button>().
		buttonList[next_btn].GetComponentInParent<Button>().interactable = true;
		set_failedattempt ();
		//btn.interactable = false;
	}

	void set_failedattempt()
	{
		if (playerturn == 0)
			playerturn = 1;
		else
			playerturn = 0;
		curr_btn = -1;
		next_btn = -1;
		curr_val = -1;
		clickturn = 0;
		setlabel ();
	}

	void set_successattempt()
	{
		curr_btn = -1;
		next_btn = -1;
		curr_val = -1;
		clickturn = 0;
		setlabel ();

		//setlabel ();
	}


}
