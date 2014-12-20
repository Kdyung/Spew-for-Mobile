/*This is a script for destructable bullets (rocks and lava). 
 * The aim is to make it general so that it can be applied to multiple tiles.
 * */
using UnityEngine;
using System.Collections;

public class DestructableBullet : MonoBehaviour {
		private Animator anim;
		// Use this for initialization
		void Start () {
			anim = this.GetComponent<Animator> ();
		}
		
		//If tile collides with something, explode it
		void OnCollisionEnter2D ( Collision2D other ){
			if (other.gameObject.tag != "Player" && !other.gameObject.name.Contains(gameObject.name)) {
				destroyBullet ();
			}
		}
		
		//Initiates destruction animation of bullet which leads to the object being destroyed via animation event
		void destroyBullet(){
			gameObject.collider2D.enabled = false;
			gameObject.rigidbody2D.transform.position = transform.position; 
			anim.SetBool ("destroy", true); //TODO: if the collider removal is not needed, just move this to the collision function

		}
		
		//This is a basic method called by an animation event from Animator to delete itself
		void destroyObject(){
			Destroy(gameObject);
		}
	}