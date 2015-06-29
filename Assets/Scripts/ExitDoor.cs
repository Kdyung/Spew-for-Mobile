using UnityEngine;
using System.Collections;

public class ExitDoor : MonoBehaviour {
	public string nextlevel; //Initialize next level in Inspector
	// Use this for initialization
	void Start () {
	}

	void OnCollisionEnter2D ( Collision2D other ){
		Debug.Log("ExitDoor collision");
		if (other.gameObject.name == "Player") {
			Debug.Log("ExitDoor collides with Player");
			//Later, add a function to freeze the game state/ make a cutscene or something.
			//Bring up a menu asking if to go to next state or return to menu.
			EndLevel ();
		}
	}
	void EndLevel(){
		Application.LoadLevel (nextlevel);
	}
}
