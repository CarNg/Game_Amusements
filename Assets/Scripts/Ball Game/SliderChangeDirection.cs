using UnityEngine;
using System.Collections;

public class SliderChangeDirection : MonoBehaviour {
	
	void OnTriggerExit(Collider other){

		if (other.tag == "Slider" && other.GetComponent<SliderMovement>().changeDirection){
			other.GetComponent<SliderMovement>().changeDirection = false;
		}
		else if (other.tag == "Slider" && !other.GetComponent<SliderMovement>().changeDirection){
			other.GetComponent<SliderMovement>().changeDirection = true;
		}

	}
}