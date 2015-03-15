using UnityEngine;
using System.Collections;

public class OnCollisionLight : MonoBehaviour {
 
	Light myLight;

	void Start(){
		myLight = GetComponentInChildren<Light>();
	}

	void OnCollisionEnter(){

		if(myLight.enabled){
			myLight.enabled = !myLight.enabled;
		}
		else {
			myLight.enabled = true;
		}
	}
}
