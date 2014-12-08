using UnityEngine;
using System.Collections;

public class DropGamePickUp : MonoBehaviour {
	private GameObject GameController;
	void Start () {
		GameController = GameObject.Find ("DropGame");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Once Collision is detected, a message is sent to the main game.
	void OnCollisionEnter2D (Collision2D col)
	{
		//Debug.Log (gameObject.name + " has collided with "+col.gameObject.name );
		if(col.gameObject.name == "Player"){
			GameController.SendMessage("pickUpCollision", gameObject);
			Debug.Log (this.gameObject.tag);
			if (this.gameObject.tag == "Food"){
				col.transform.SendMessage("Eat");
			}
		}
	}
}
