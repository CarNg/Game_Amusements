using UnityEngine;
using System.Collections;

public class OnCollisionSound : MonoBehaviour {

	void OnCollisionEnter(){
		audio.Play();
	}
}
