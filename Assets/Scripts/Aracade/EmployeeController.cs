using UnityEngine;
using System.Collections;

public class EmployeeController : MonoBehaviour {

	
	Animator animator;
	int animationInt;

	bool facingBooth;
	public bool atBooth;
	public bool nearBooth;

	Transform myTransform;

	float direction;
	public GameObject Player;
	public Transform PlayerPosition;
	
	public Transform GamePosition;
	Vector3 booth = new Vector3(-6.5f, 0f, -2f);
	Vector3 game = new Vector3(-6.5f, 0f, 3.6f);

	bool exchanging;
	public GameObject dialog;
	public GameObject data;
	
	void Start(){
		myTransform = transform;
		animator = GetComponent<Animator>();
	}

	void Update(){
		animator.SetInteger ("animationInt", animationInt);
		direction = Player.transform.eulerAngles.y;

		if (direction > 180){
			facingBooth = true;		
		}
		else{
			facingBooth = false;
		}

		if (atBooth){
			if(facingBooth){
				GoOver();
			}
			else{
				LookOver();
			}
		}

		else{
			if(nearBooth){
				LookOver();
			}
			else{
				WorkAway();
			}
		}
	}

	void WorkAway(){
		animationInt = 1;

		Quaternion rotation = Quaternion.LookRotation(GamePosition.position - myTransform.position);
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, rotation, Time.deltaTime * 2.5f);

		transform.position = Vector3.MoveTowards(transform.position, game, 1.5f * Time.deltaTime);
		if(transform.position == game){
			animationInt = 2;
		}
	}

	void LookOver(){
		exchanging = false;
		dialog.GetComponent<TextMesh>().text = "";

		animationInt = 0;

		Quaternion rotation = Quaternion.LookRotation(PlayerPosition.position - myTransform.position);
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, rotation, Time.deltaTime * 2.5f);
	}

	void GoOver(){
		if(transform.position != booth){
			animationInt = 1;
			transform.eulerAngles = new Vector3(0, 180, 0);
			transform.position = Vector3.MoveTowards(transform.position, booth, 1.5f * Time.deltaTime);
		}

		else{
			Quaternion rotation = Quaternion.LookRotation(PlayerPosition.position - myTransform.position);
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation, rotation, Time.deltaTime * 2.5f);
			animationInt = 0;

			if (data.GetComponent<ArcadeData>().tickets == 0 && !exchanging){
				dialog.GetComponent<TextMesh>().text = "Hi! We exchange your tickets for coins here. \n"
														+ "You can win tickets by playing some games!";
			}
			else if (data.GetComponent<ArcadeData>().tickets > 0){
				exchanging = true;
				dialog.GetComponent<TextMesh>().text = "Here, let me exchange those tickets for you!";
				Invoke("exchangeTickets", 2f);
			}
		}
	}

	void exchangeTickets(){
		data.GetComponent<ArcadeData> ().coins = data.GetComponent<ArcadeData> ().coins + data.GetComponent<ArcadeData> ().tickets;
		data.GetComponent<ArcadeData>().tickets = 0;
		dialog.GetComponent<TextMesh>().text = "There you go. Enjoy!";
	}
}
