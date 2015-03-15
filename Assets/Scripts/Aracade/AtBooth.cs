using UnityEngine;
using System.Collections;

public class AtBooth : MonoBehaviour {

	public GameObject Employee;

	void OnTriggerEnter(Collider other){
		Employee.GetComponent<EmployeeController>().atBooth = true;
	}

	void OnTriggerExit(Collider other){
		Employee.GetComponent<EmployeeController>().atBooth = false;
	}
}
