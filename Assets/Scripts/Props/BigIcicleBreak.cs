using UnityEngine;
using System.Collections;

public class BigIcicleBreak : MonoBehaviour {
	private int damage = 10;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = this.GetComponentInParent<Animator> ();
	}
	
	//If Icicle takes enough damage, trigger falling
	//alt: if support of icicle disappears.
	void OnCollisionEnter2D ( Collision2D other ){
		if ( anim.GetBool("falling") == false){
			//If objectcollides with floor after activated, destroy it
			if( other.gameObject.tag == "TileDestroyer" ){
				damage--;
				anim.Play("big_icicle_break_unstable");
				Debug.Log("damage = " + damage);
				if (damage <= 0){
					anim.SetBool ("falling", true);
				}
			}
		}
	}
	void stopAnim(){
		anim.speed = 0;
	}
}
