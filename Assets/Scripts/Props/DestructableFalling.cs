using UnityEngine;
using System.Collections;

public class DestructableFalling : MonoBehaviour {
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
	}
	
	//If tile collides with something that destroys tiles, destroy that object and do tile animation
	void OnCollisionEnter2D ( Collision2D other ){
		//If objectcollides with floor after activated, destroy it
		if( other.gameObject.tag == "Platforms" ){
			destroyObject();
		}
	}
	
	//Initiates destruction animation of tile which leads to the object being destroyed 
	void destroyAnim(){
		anim.SetBool ("destroy", true);
		gameObject.GetComponent<Collider2D>().enabled = false;
	}
	
	//This is a basic method called by an animation event from Animator to delete the tile gameobject
	void destroyObject(){
		Destroy(gameObject);
	}
}
