using UnityEngine;
using System.Collections;

public class SliderMovement : MonoBehaviour {

	public bool changeDirection;

	// Update is called once per frame
	void Update () {

		if (changeDirection) {
			transform.Translate(0.6f * Time.deltaTime, 0 , 0);	
		}
		else {
			transform.Translate(-0.6f * Time.deltaTime, 0 , 0);	
		}

	}
}
