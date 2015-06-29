
using UnityEngine;
using System.Collections;
/*This is a script for destructable tiles. 
 * The aim is to make it general so that it can be applied to multiple tiles.
 * */
public class DestructableTile : MonoBehaviour {
	
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
	}
	
	//If tile collides with something that destroys tiles, destroy that object and do tile animation
	void OnCollisionEnter2D ( Collision2D other ){
		//Debug.Log ("tile_0 has collided with "+col.gameObject.name );
		if( other.gameObject.tag == "TileDestroyer" ){
			destroyTile();
		}
		//Destroy other object if rock from Drop Game
		if (other.gameObject.name == "rock_drop" || other.gameObject.name == "rock_drop(Clone)") {
			Destroy (other.gameObject);		
		}
	}
	
	//Initiates destruction animation of tile which leads to the object being destroyed 
	void destroyTile(){
		anim.SetBool ("destroy", true);
		gameObject.GetComponent<Collider2D>().enabled = false;
	}
	
	//This is a basic method called by an animation event from Animator to delete the tile gameobject
	void destroyObject(){
		Destroy(gameObject);
	}
}