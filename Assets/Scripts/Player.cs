/** 
 * This is a Player script that is for demoing that uses keyboard inputs
 * and applies animations.
 * Has Button inputs built in through the Project Input Settings.
 * Contains button response for both keyboard and mobile buttons simultaneously.
 **/

using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Vector2 speed = new Vector2(10,10);
	public float inputX;
	
	private float jumpForce = 1200f;

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


	//takes in public audio source (since this is simple game, only two needed).
	public AudioSource spewAudio;
	public AudioSource jumpAudio; 

	public ButtonController buttons;



	// Use this for initialization
	void Start () {
		facingRight = true;
		spewing = false;

		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Activate Input Settings (Keyboard) if not on mobile
		if ( Application.platform != RuntimePlatform.Android){
			if(!buttons.isActive){ //If the button controller is being used, deactivate Keyboard controls
				inputX = Input.GetAxis ("Horizontal");

				if(Input.GetButtonDown("Jump")){
					Jump ();
				}
				if (Input.GetButtonDown ("Spew")) {
					Spew ();
					spewing = true;
				} else if (Input.GetButtonUp("Spew")){
					spewing = false;
				}
			}
		}

		Vector2 movement = new Vector2 (speed.x * inputX, rigidbody2D.velocity.y);
		rigidbody2D.velocity = movement;//Apply movement to rigidbody2D


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

		//Flipping Animation
		if (inputX > 0 && !facingRight){
			Flip();
		} else if (inputX < 0 && facingRight){
			Flip();
		}
	}

	void FixedUpdate() {
		//groundCheck for grounded Character
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

	}
	//TODO

	void onCollisionEnter2D(Collision2D other){
		Debug.Log (other + " has touched Player");
		if (other.gameObject.tag == "Food") {
			Debug.Log("FOOD has touched player");
			Eat();
		}
	}

	//External access of InputX
	public void getInputX(float x){
		inputX = x;
	}

	public void Eat(){
		animation.Play("player_omnom");
	}

	//Jump defined in function to allow calling from external scripts using natural conditions
	public void Jump(){
			if (grounded) {
				rigidbody2D.AddForce (new Vector2 (0f, jumpForce));
				jumpAudio.Play ();
				anim.SetBool ("grounded", false);
			}
	}

	//Spew defined in function
	public void Spew(){
			spewAudio.Play();
	}

	//Reverses the x scale for animation purposes
	void Flip(){
		facingRight = !facingRight;
		Vector3 thisScale = transform.localScale;
		thisScale.x = -thisScale.x;
		transform.localScale = thisScale;
	}
}



