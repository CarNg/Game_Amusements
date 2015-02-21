using UnityEngine;
using System.Collections;

public class JackRotater : MonoBehaviour {

	bool changeDirection = false;

	void Update () {

		if(transform.eulerAngles.z >= 230){
			changeDirection = true;
		}
		else if (transform.eulerAngles.z <= 120){
			changeDirection = false;
		}

		if (changeDirection) {
			transform.Rotate (0, 0, -0.5f, Space.Self);
		}
		else {
			transform.Rotate (0, 0, 0.5f, Space.Self);	
		}

	}
}
