using UnityEngine;
using System.Collections;

public class FallTrigger : MonoBehaviour {

	public GameObject Lives;
	public GameObject fallCount;

	public GameObject Jack;

	public GameObject StartLose;

	void OnTriggerEnter(Collider other){

		GetComponent<AudioSource>().Play ();
		Destroy(other.gameObject);

		Lives.GetComponent<GameData>().lives -= 1;

		if (Lives.GetComponent<GameData>().lives == 2){
			fallCount.GetComponent<TextMesh> ().text = "X";
			Jack.GetComponent<FireProjectile> ().repeatRate = 1.5f;		
		}
		else if (Lives.GetComponent<GameData>().lives == 1){
			fallCount.GetComponent<TextMesh> ().text = "X X";
			Jack.GetComponent<FireProjectile> ().repeatRate = 1f;
		}
		else if (Lives.GetComponent<GameData>().lives <= 0){
			StartLose.GetComponent<StartLose>().lost();
			fallCount.GetComponent<TextMesh> ().text = "X X X";
		}
		else {
			fallCount.GetComponent<TextMesh> ().text = "";
		}

	}
}
