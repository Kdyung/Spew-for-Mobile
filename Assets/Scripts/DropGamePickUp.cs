using UnityEngine;
using System.Collections;

public class DropGamePickUp : MonoBehaviour {
	// Use this for initialization
	public DropGameController DropGameController;
	public GameObject DropGame;
	void Start () {
		DropGame = GameObject.Find ("DropGame");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D (Collision2D col)
	{
		Debug.Log (gameObject.name + " has collided with "+col.gameObject.name );
		if(col.gameObject.name == "Player"){
			DropGame.SendMessage("pickUpCollision", gameObject);
		}
	}
}
