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
	
	private float jumpForce = 1500f;
	
	public bool grounded;

	public GameObject spewObject;//the object created by spewing

	//Animation Control variables
	private Animator anim;
	private bool facingRight;
	public bool spewing;

	//takes in public audio source (since this is simple game, only two needed).
	public AudioSource spewAudio;
	public AudioSource jumpAudio; 
	public AudioSource eatAudio;

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
					spewing = true;
					Spew ();
				}
				if (Input.GetButtonUp("Spew")){
					CancelSpew ();
					spewing = false;
				}
			}
		}

		Vector2 movement = new Vector2 (speed.x * inputX, GetComponent<Rigidbody2D>().velocity.y);
		GetComponent<Rigidbody2D>().velocity = movement;//Apply movement to rigidbody2D


		//Refresh Animator parameters
		if (inputX != 0) {
			anim.SetBool ("moving", true);
		} else {
			anim.SetBool ("moving", false);
		}
		//Spewing is a continuous function that 
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
		//grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
	}

	//trigger-based ground checking
	void OnTriggerEnter2D (Collider2D other) {
		if (other.GetComponent<Collider2D>().gameObject.layer == LayerMask.NameToLayer("Platforms")){
			grounded = true;
		}
	}
	void OnTriggerStay2D (Collider2D other) {
		if (other.GetComponent<Collider2D>().gameObject.layer == LayerMask.NameToLayer("Platforms"))
			grounded = true;
	}
	void OnTriggerExit2D (Collider2D other) {
		if (other.GetComponent<Collider2D>().gameObject.layer == LayerMask.NameToLayer("Platforms"))
			grounded = false;
	}

	//External access of InputX
	public void getInputX(float x){
		inputX = x;
	}

	public void Eat(){
		//eatAudio.Play ();
		anim.Play("player_omnom");
	}

	//Jump defined in function to allow calling from external scripts using natural conditions
	public void Jump(){
			if (grounded) {
			    anim.SetBool ("grounded", false);
				GetComponent<Rigidbody2D>().AddForce (new Vector2 (0f, jumpForce));
				if (!spewing)
					jumpAudio.Play ();

			}
	}

	//Spew defined in function
	public void Spew(){
		spewAudio.Play();
		InvokeRepeating("SpawnLava",0.01f,0.1f);
	}

	public void CancelSpew(){
		CancelInvoke ("SpawnLava");
	}

	public void SpawnLava(){
			//generate a lava ball instance
			GameObject Clone;
			int spew_direction = facingRight ? 1 : -1; // the x direction of the force
			Vector3 spewPoint = new Vector3 (transform.position.x + spew_direction * 0.6f, transform.position.y + 1.2f, transform.position.z); 
			Clone = (Instantiate (spewObject, spewPoint, transform.rotation)) as GameObject;
			//add force to the spawned objected
	
			Vector2 spewForce = new Vector2 (400 * spew_direction, 100);
			Clone.GetComponent<Rigidbody2D>().AddForce (spewForce);
	}

	//Reverses the x scale for animation purposes
	void Flip(){
		facingRight = !facingRight;
		Vector3 thisScale = transform.localScale;
		thisScale.x = -thisScale.x;
		transform.localScale = thisScale;
	}
}



