using UnityEngine;
using System.Collections;

public class DestroyGameOver : MonoBehaviour {

	GameObject screen;

	void Start(){
		screen = GameObject.Find ("Start Lose Screen");
	}

	void Update () {
	
		if (screen.GetComponent<StartLose>().loseMenu) {
			Destroy (gameObject);
		}

	}
}
