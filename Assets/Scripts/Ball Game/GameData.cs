using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {
	
	public GameObject PointsHUD;
	public int points;

	public GameObject CoinsHUD;
	public int coins;

	public GameObject LivesHUD;
	public int lives;

	public GameObject HighScoreHUD;
	public int score;

	public int tickets;

	public bool Play;
	
	void Update () {
		if(Play){
			PointsHUD.GetComponent<GUIText>().text = "Points: " + points.ToString();
			LivesHUD.GetComponent<GUIText>().text = "Lives: " + lives.ToString();
		}
		else{
			PointsHUD.GetComponent<GUIText>().text = "";
			LivesHUD.GetComponent<GUIText>().text = "";
		}

		CoinsHUD.GetComponent<GUIText>().text = "Coins: " + coins.ToString();
		HighScoreHUD.GetComponent<TextMesh>().text = "High Score: \n" + score.ToString();
	}

	void Start(){
		GetState();
	}

	void GetState(){
		if(PlayerPrefs.HasKey("coins")){
			coins = PlayerPrefs.GetInt("coins");
			tickets = PlayerPrefs.GetInt("tickets");
			score = PlayerPrefs.GetInt("highScore");
		}
	}

	public void SetState(){
		PlayerPrefs.SetInt("coins", coins);
		PlayerPrefs.SetInt ("tickets", tickets);
		PlayerPrefs.SetInt("highScore", score);

		PlayerPrefs.Save();
	}
}
