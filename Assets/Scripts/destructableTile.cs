using UnityEngine;
using System.Collections;

public class destructableTile : MonoBehaviour {
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	//If tile collides with something that destroys tiles, destroy that object and do tile animation
	void OnCollisionEnter (Collision col)
	{
		Debug.Log ("tile_0 has collided");
		if(col.gameObject.tag == "TileDestroyer"){
			Destroy(col.gameObject);
			destroyTile();
		}
	}

	
	void destroyTile(){
		anim.SetBool ("destroy", true);
	}

	void destroyObject(){
		DestroyObject (this);
	}
}
