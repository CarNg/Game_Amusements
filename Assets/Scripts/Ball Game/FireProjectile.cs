using UnityEngine;
using System.Collections;

public class FireProjectile : MonoBehaviour {

	public Rigidbody Ball;
	public float repeatRate;
	
	public void shootingStart(){
		InvokeRepeating ("shoot", 1, repeatRate);
	}

	void shoot(){
		Rigidbody newPro = Instantiate (Ball, transform.position + (transform.up/2), transform.rotation)
		as Rigidbody;
		newPro.AddForce (newPro.transform.up * 500);
		audio.Play();
	}

	public void stop(){
		CancelInvoke();
	}
}
