using UnityEngine;
using System.Collections;

public class destructableTile : MonoBehaviour {
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	//If tile collides with something that destroys tiles, destroy that object and do tile animation
	void OnCollisionEnter2D (Collision2D col)
	{
		Debug.Log ("tile_0 has collided with "+col.gameObject.name );
		if(col.gameObject.tag == "TileDestroyer"){
			Destroy(col.gameObject);
			destroyTile();
		}
	}

	//Initiates destruction animation of tile which leads to the object being destroyed 
	void destroyTile(){
		anim.SetBool ("destroy", true);
		gameObject.collider2D.enabled = false;
	}

	//This is a basic method called by an animation event from Animator
	void destroyObject(){
		Destroy(gameObject);
	}
}
