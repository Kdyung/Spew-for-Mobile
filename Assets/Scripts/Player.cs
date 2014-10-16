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
		//from http://unity3d.com/learn/tutorials/modules/beginner/2d/2d-controllers
	public bool grounded;
	public Transform groundCheck;	//Assigned through inspector
	public LayerMask whatIsGround; //Assigned through inspector
	float groundRadius = 0.2f;



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
	
	// Update is called once per frame
	void Update () {

		inputX = Input.GetAxis("Horizontal");
		Vector2 movement = new Vector2 (speed.x * inputX, rigidbody2D.velocity.y);

		//Jumping
		//if(Input.GetAxis("Jump")>0 && grounded){//Jump Defined in Input Manager, Jumpforce = 300
		if(Input.GetKeyDown(KeyCode.W) && grounded){ //JumpForce = 1000;
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			jumpButton.audio.Play();
			anim.SetBool ("grounded",false);
		}

		//Apply movement to rigidbody2D
		rigidbody2D.velocity = movement;

		//Refreshes Animator parameters if moving left/right
		if (inputX != 0) {
						anim.SetBool ("moving", true);
				} else {
						anim.SetBool ("moving", false);
				}
		//Flipping Animation controller
		if (inputX > 0 && !facingRight){
			Flip();
		} else if (inputX < 0 && facingRight){
			Flip();
		}
	}

	void FixedUpdate() {
		
		//groundCheck
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);




	}
	
	//function that reverses the x scale for animation purposes
	void Flip(){
		facingRight = !facingRight;
		Vector3 thisScale = transform.localScale;
		thisScale.x = -thisScale.x;
		transform.localScale = thisScale;
	}
}



