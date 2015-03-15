using UnityEngine;
using System.Collections;

public class StartLose : MonoBehaviour {

	public GameObject pauseGame;

	public GameObject Jack;
	public GameObject Table;

	public GameObject GameData;

	bool startMenu;
	public bool loseMenu;
	public Texture lose;

	public GameObject Tickets;
	int ticketsWon;

	public GameObject Warning;
	int coins;

	void Start(){
		startMenu = true;
		loseMenu = false;
		gameObject.GetComponent<GUIText> ().text = "";
		Table.GetComponent<BoardRotate>().enabled = false;
		Table.GetComponent<AudioSource> ().enabled = false;
	}

	void Update () {

		coins = GameData.GetComponent<GameData> ().coins;

		if (Input.GetButtonDown ("Jump") && startMenu && coins > 0) {
			play();
		}
		else if (Input.GetKeyDown ("r") && startMenu && coins > 0) {
			Application.LoadLevel("Arcade");
		}
		else if (Input.GetKeyDown ("r") && loseMenu){
			Application.LoadLevel(Application.loadedLevel);
		}
		else if (Input.GetKeyDown ("q") && loseMenu){
			Application.LoadLevel("Arcade");
		}


		if (coins == 1 && startMenu) {
			Warning.GetComponent<GUIText>().text = " <color=yellow>Careful!</color> This is your <color=yellow>last coin</color>. If you run out of tickets and coins, \n"
				+ "you will need to <color=yellow>reset the game</color> for more coins. \n"
					+ "<color=yellow>However</color>, this will also reset your high score!";
		}
		else if(coins == 0 && startMenu){
			Warning.GetComponent<GUIText>().text = "Sorry, you don't have enough to play!";
		}
		else {
			Warning.GetComponent<GUIText>().text = "";
		}

	}

	void play(){
		pauseGame.SetActive (true);

		GameData.GetComponent<GameData> ().coins = GameData.GetComponent<GameData> ().coins -= 1;
		GameData.GetComponent<GameData> ().Play = true;

		gameObject.GetComponent<GUITexture> ().enabled = false;

		Table.GetComponent<BoardRotate> ().enabled = true;
		Table.GetComponent<AudioSource> ().enabled = true;
		Jack.GetComponent<FireProjectile> ().shootingStart ();

		startMenu = false;
	}

	public void lost(){
		pauseGame.SetActive (false);

		ticketsWon = GameData.GetComponent<GameData> ().points / 20000;
		GameData.GetComponent<GameData> ().tickets = GameData.GetComponent<GameData> ().tickets + ticketsWon;
		GameData.GetComponent<GameData> ().SetState ();
		GameData.GetComponent<GameData> ().Play = false;

		loseMenu = true;
		GetComponent<GUITexture>().texture = lose;
		gameObject.GetComponent<GUITexture> ().enabled = true;
		gameObject.GetComponent<GUIText> ().text = GameData.GetComponent<GameData> ().points.ToString();
		Tickets.GetComponent<GUIText> ().text = ticketsWon.ToString();

		Jack.GetComponent<FireProjectile> ().stop ();
		Table.GetComponent<BoardRotate> ().enabled = false;
		Table.GetComponent<AudioSource> ().enabled = false;
	}
}
