using UnityEngine;
using System.Collections;

public class NearBooth : MonoBehaviour {

	public GameObject Employee;
	
	void OnTriggerEnter(Collider other){
		Employee.GetComponent<EmployeeController>().nearBooth = true;
	}
	
	void OnTriggerExit(Collider other){
		Employee.GetComponent<EmployeeController>().nearBooth = false;
	}
}
