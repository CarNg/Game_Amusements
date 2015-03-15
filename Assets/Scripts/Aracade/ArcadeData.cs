using UnityEngine;
using System.Collections;

public class ArcadeData : MonoBehaviour {

	public GameObject TicketsHUD;
	public int tickets;
	
	public GameObject CoinsHUD;
	public int coins;

	public GameObject Reset;
	bool resetConfirm;
	
	void Start(){
		resetConfirm = false;
		GetState();
	}

	void Update () {
		CoinsHUD.GetComponent<GUIText>().text = "Coins: " + coins.ToString();
		TicketsHUD.GetComponent<GUIText>().text = "Tickets: " + tickets.ToString();

		if(coins == 0 && tickets == 0){
			if(!resetConfirm) {
					Reset.GetComponent<GUIText>().text =
					"You have run out of tickets and coins. You can reset the game for coins. \n"
					+"<color=yellow>However!</color> This will also reset any high scores you currently hold. You can reset by pressing '<color=yellow>R</color>'.";
			}
			else {
				Reset.GetComponent<GUIText>().text =
				"<color=yellow>Are you sure</color> you want to reset the game? (Press '<color=yellow>R</color>' to confirm or '<color=yellow>C</color>' to cancel.)";
			}


				if(Input.GetKeyDown ("r") && !resetConfirm) {
					resetConfirm = true;
				}
				else if (Input.GetKeyDown ("r") && resetConfirm) {
					ResetState();
					Application.LoadLevel(Application.loadedLevel);
				}
				else if (Input.GetKeyDown ("c") && resetConfirm) {
					resetConfirm = false;
				}
		}
		else {
			Reset.GetComponent<GUIText>().text = "";
		}
	}
	
	void OnApplicationQuit() {
		SetState();
	}
	
	void GetState(){
		if(PlayerPrefs.HasKey("coins")) {
			coins = PlayerPrefs.GetInt("coins");
			tickets = PlayerPrefs.GetInt("tickets");
		}
	}

	public void SetState() {
		PlayerPrefs.SetInt("tickets", tickets);
		PlayerPrefs.SetInt("coins", coins);
		
		PlayerPrefs.Save();
	}

	void ResetState() {
		PlayerPrefs.SetInt("tickets", 0);
		PlayerPrefs.SetInt("coins", 5);
		PlayerPrefs.SetInt("highScore", 0);

		PlayerPrefs.Save();
	}

}
