using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Vector2 speed = new Vector2(10,10);
	public Vector2 movement;
	public bool grounded = true;
//	public float onGround;
	public float jumpForce = 1000f;

//	public LayerMask whatIsGround;

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.name == "destructible" ||
		   collision.gameObject.name == "unmeltable")
		{
			grounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.name == "tile1" ||
						collision.gameObject.name == "tile2") 
		{
			grounded = false;
		}
	}


	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis("Horizontal");
//		float inputY = Input.GetAxis("Vertical");

		/**Movement of player character: horizontal controlled, vertical = jumping**/
/*		if (grounded) 
		{
			onGround = speed.y * inputY;
		}
		else 
		{			
			onGround = rigidbody2D.velocity.y;
		}
*/
		movement = new Vector2 (speed.x * inputX, rigidbody2D.velocity.y);

	}

	void FixedUpdate() {
		// 5 - Move the game object

		rigidbody2D.velocity = movement;
		if(grounded && Input.GetKeyDown (KeyCode.W)){
			rigidbody2D.AddForce (new Vector2(0,jumpForce));
//			grounded = false;
		}

	}
}
