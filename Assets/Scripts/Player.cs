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
	public bool spewing;


	//takes in button gameobject as well
	//The buttons
	//private GameObject rightButton;
	//private GameObject leftButton;
	private GameObject spewButton;
	private GameObject jumpButton;


	public MoveLeft leftButton; //Assigned in Inspector
	public MoveRight rightButton; //Assigned in Inspector



	// Use this for initialization
	void Start () {
		//leftButton = GameObject.Find ("button_left");
		//rightButton = GameObject.Find("button_right");
		jumpButton = GameObject.Find ("button_jump");
		spewButton = GameObject.Find ("button_spew");

		facingRight = true;
		spewing = false;

		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.platform == RuntimePlatform.WindowsEditor) {
		}else if (Application.platform == RuntimePlatform.WindowsPlayer){
			inputX = Input.GetAxis ("Horizontal");
		}

		Vector2 movement = new Vector2 (speed.x * inputX, rigidbody2D.velocity.y);

		//Jumping
		if(Input.GetButtonDown("Jump")){ //JumpForce = 1000;
			Jump ();
		}

		if (Input.GetButtonDown ("Spew")) {
			Debug.Log ("Spewing!");
				Spew ();
				spewing = true;
		} else if (Input.GetButtonUp("Spew")){
			Debug.Log ("NotSpewing!");
				spewing = false;
		}




		//Apply movement to rigidbody2D
		rigidbody2D.velocity = movement;

		//Refresh Animator parameters
		if (inputX != 0) {
					anim.SetBool ("moving", true);
			} else {
					anim.SetBool ("moving", false);
		}
		if (spewing) {
			anim.SetBool ("spewing", true);
			} else {
			anim.SetBool ("spewing", false);
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

	//External access of InputX
	public void getInputX(float x){
		inputX = x;
	}


	//Jump defined in function to allow calling from external scripts using natural conditions
	public void Jump(){
			if (grounded) {
				rigidbody2D.AddForce (new Vector2 (0f, jumpForce));
				jumpButton.audio.Play ();
				anim.SetBool ("grounded", false);
			}
	}

	void Spew(){
			spewButton.audio.Play();
	}

	//function that reverses the x scale for animation purposes
	void Flip(){
		facingRight = !facingRight;
		Vector3 thisScale = transform.localScale;
		thisScale.x = -thisScale.x;
		transform.localScale = thisScale;
	}
}



