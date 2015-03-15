using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {

	bool atGame = false;
	public GameObject text;

	public GameObject data;
	public GameObject pause;

	void OnTriggerEnter(){
		text.GetComponent<TextMesh> ().text = "Hit 'space' to play!";
		pause.SetActive (false);
		atGame = true;
	}

	void OnTriggerExit(){
		text.GetComponent<TextMesh> ().text = "";
		pause.SetActive (true);
		atGame = false;
	}

	void Update(){
		if(Input.GetKeyDown ("space") && atGame){
			data.GetComponent<ArcadeData>().SetState();
			Application.LoadLevel("Ball Game");
		}
	}
}
