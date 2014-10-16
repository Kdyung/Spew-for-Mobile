/** 
 * This is a Player script that is for demoing that uses keyboard inputs
 * and applies animations.
 * 
 **/

using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Vector2 speed = new Vector2(10,10);
	public float inputX;

//	public float onGround;
	public float jumpForce = 1000f;

	//check for ground collision
	public bool grounded;
	public Transform groundEnd;

	//Animation Control variables
	private Animator anim;
	private bool facingRight;



	//takes in button input as well
	//private GameObject rightButton;
	//private GameObject leftButton;
	private GameObject spewButton;
	private GameObject jumpButton;



	// Use this for initialization
	void Start () {
		//leftButton = GameObject.Find ("button_left");
		//rightButton = GameObject.Find("button_right");
		jumpButton = GameObject.Find ("button_jump");
		spewButton = GameObject.Find ("button_spew");

		facingRight = true;
		anim = GetComponent<Animator> ();
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		string hitObject = collision.gameObject.name;
		if(hitObject == "tile_1" || hitObject == "tile_0")
		{
			grounded = true;
			Debug.Log("grounded");
		}
	}
	void OnCollisionExit2D(Collision2D collision)
	{
		string hitObject = collision.gameObject.name;
		if (hitObject == "tile_1" || hitObject == "tile_0") 
		{
			grounded = false;
			Debug.Log("not grounded");
		}
	}


	// Update is called once per frame
	void Update () {
		inputX = Input.GetAxis("Horizontal");
		Vector2 movement = new Vector2 (speed.x * inputX, rigidbody2D.velocity.y);
		//Jumping @TODO
		if(Input.GetKeyDown(KeyCode.W) && grounded){
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			jumpButton.audio.Play();
		}
		
		rigidbody2D.velocity = movement;



		//Refreshes Animator parameters if moving left/right
		if (inputX != 0) {
			anim.SetBool("moving",true);
		}else{
			anim.SetBool ("moving",false);
		}



		//Flipping Animation controller
		if (inputX > 0 && !facingRight) 
		{
				Flip();
		} else if (inputX < 0 && facingRight){
				Flip();
		}

		//Apply movement to rigidbody2D
		rigidbody2D.velocity = movement;
	}






	//function that reverses the x scale for animation purposes
	void Flip(){
		facingRight = !facingRight;
		Vector3 thisScale = transform.localScale;
		thisScale.x = -thisScale.x;
		transform.localScale = thisScale;
	}

	void FixedUpdate() {
	}
	
	/*
	public bool isGrounded(){
				bool result = Physics2D.Linecast (myPos, groundCheckPos, 1 << LayerMask.NameToLayer ("Ground"));
				if (result) {
						Debug.DrawLine (myPos, groundCheckPos, Color.green, 0.5f, false);
				} else {
						Debug.DrawLine (myPos, groundCheckPos, Color.red, 0.5f, false);
				}
				return result;
		}
		*/
}



