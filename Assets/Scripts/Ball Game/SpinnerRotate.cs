using UnityEngine;
using System.Collections;

public class SpinnerRotate : MonoBehaviour {

	public bool differentDirection;

	void FixedUpdate () {

		if (differentDirection){
			transform.Rotate (0, 2f, 0);
		}
		else{
			transform.Rotate (0, -2f, 0);
		}
	}
}
