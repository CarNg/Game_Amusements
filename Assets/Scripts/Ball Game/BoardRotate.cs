using UnityEngine;
using System.Collections;

public class BoardRotate : MonoBehaviour {

	void Update () {
		transform.Rotate (0, Input.GetAxis ("Horizontal") * -100 * Time.deltaTime, 0, Space.Self);
	}
}