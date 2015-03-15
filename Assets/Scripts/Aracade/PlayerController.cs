using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Animator animator;

	float vAxis;
	float hAxis;
	
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	void Update () {
		vAxis = Input.GetAxis("Vertical");
		hAxis = Input.GetAxis("Horizontal");
	}

	void FixedUpdate(){
		animator.SetFloat ("vAxisInput", vAxis);
		animator.SetFloat ("hAxisInput", hAxis);
	}

}
