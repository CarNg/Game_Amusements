using UnityEngine;
using System.Collections;

public class ScoreTrigger : MonoBehaviour {

	Light myLight;

	public int PointsToAdd;
	public GameObject GameData;

	void Start(){
		myLight = GetComponentInChildren<Light> ();
	}

	void OnTriggerEnter(Collider other){
		GetComponent<AudioSource>().Play ();
		Destroy(other.gameObject);

		GameData.GetComponent<GameData> ().points = GameData.GetComponent<GameData> ().points + PointsToAdd;
	
		if(GameData.GetComponent<GameData> ().points > GameData.GetComponent<GameData> ().score){
			GameData.GetComponent<GameData> ().score = GameData.GetComponent<GameData> ().score + PointsToAdd;
		}

		if(myLight.enabled){
			myLight.enabled = !myLight.enabled;
			Invoke ("LightOpposite", 1);
		}
		else {
			myLight.enabled = true;
			Invoke ("LightOpposite", 1);
		}
	}
	
	void LightOpposite(){
		if(myLight.enabled){
			myLight.enabled = !myLight.enabled;
		}
		else {
			myLight.enabled = true;
		}
	}
}
