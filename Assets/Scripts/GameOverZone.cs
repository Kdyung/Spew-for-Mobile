using UnityEngine;
using System.Collections;

public class GameOverZone : MonoBehaviour {

	private GameObject GameController;
	// Use this for initialization
	void Start () {
		GameController = GameObject.Find ("DropGame");
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log ("GameOverZone collision with "+other.gameObject );
		if (other.gameObject.layer == LayerMask.NameToLayer("Player")) {
			Debug.Log ("Player hit gameover zone");
			GameController.SendMessage ("getGameOver");
		} else if ( other.gameObject.layer == LayerMask.NameToLayer("Props") ){
			Destroy (other.gameObject);
		}
	}
}
