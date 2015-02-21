using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {

	bool atGame = false;
	public GameObject text;

	public GameObject data;

	void OnTriggerEnter(){
		text.GetComponent<TextMesh> ().text = "Hit 'space' to play!";
		atGame = true;
	}

	void OnTriggerExit(){
		text.GetComponent<TextMesh> ().text = "";
		atGame = false;
	}

	void Update(){
		if(Input.GetKeyDown ("space") && atGame){
			data.GetComponent<ArcadeData>().SetState();
			Application.LoadLevel("Ball Game");
		}
	}
}
