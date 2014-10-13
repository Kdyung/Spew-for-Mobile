/** 
 * This is a Player script that is for demoing that uses keyboard inputs
 * and applies animations.
 * 

 **/

using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Vector2 speed = new Vector2(10,10);
	public Vector2 movement;
	public bool grounded = true;
//	public float onGround;
	public float jumpForce = 1000f;

	//Animation Control
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
		if(collision.gameObject.name == "Platforms")
		{
			grounded = true;
			System.Console.WriteLine("grounded");
		}
	}
	void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.name == "Platforms") 
		{
			grounded = false;
			System.Console.WriteLine("not grounded");
		}
	}


	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		movement = new Vector2 (speed.x * inputX, rigidbody2D.velocity.y);
		rigidbody2D.velocity = movement;

		if (inputX != 0) {
			anim.SetBool("moving",true);
		}else{
			anim.SetBool ("moving",false);
			}

		if(grounded && Input.GetKeyDown(KeyCode.W)){
			rigidbody2D.AddForce (new Vector2(0,jumpForce));
			jumpButton.audio.Play();
		}

		//Animation controller
		if (inputX > 0 && !facingRight) 
		{
				Flip();
		} else if (inputX < 0 && facingRight){
				Flip();
		}

	}

	//Reverses xscale
	void Flip(){
		facingRight = !facingRight;
		Vector3 thisScale = transform.localScale;
		thisScale.x = -thisScale.x;
		transform.localScale = thisScale;
	}

	void FixedUpdate() {
	}



}
