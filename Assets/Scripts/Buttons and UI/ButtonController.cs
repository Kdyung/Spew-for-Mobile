using UnityEngine;
using System.Collections;

/*This Script compiles all of the button functions. This is used 
 * because all the buttons do is access the Player Controller Player.cs
 * anyways so why not just minimize the code.
 * The Button is normally applied to a Buttoncontroller prefab containing each
 * individual button. Buttons are then assigned through the inspector.
 * 11-27-14 The Controller Layer is the layer used for all buttons for this project,
 * but the layer for masking can be assigned through inspector in case this changes.
 * 
 * */
public class ButtonController : MonoBehaviour {

	//The following variables are assigned through Inspector
	public LayerMask ButtonLayer; //Layer mask for avoiding collision with non gui

	public GameObject ButtonLeft;
	public GameObject ButtonRight;
	public GameObject ButtonJump;
	public GameObject ButtonSpew;

	public Player hero;//

	public bool isActive; //flag for if buttons are being used or not
	public bool showButtons;

	// Use this for initialization
	void Start () {
		showButtons = (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.Android);
		Debug.Log ("Buttons Active = " + showButtons);
		//Hides the Buttons if playing on the wrong platform
		/** //For some reason following script does not work anymore
		//ButtonLeft.GetComponent<SpriteRenderer> ().enabled = showButtons;
		//ButtonLeft.SetActive (showButtons);
		**/
		gameObject.SetActive (showButtons);
	}
	
	
	// Update is called once per frame
	void Update()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			for (var i = 0; i < Input.touchCount; i++) { //for loop added to read multiple touches
				if (Input.touchCount > 0)
				{
					if (Input.GetTouch(i).phase == TouchPhase.Began)
					{ 
						CheckTouch(Input.GetTouch(i).position, "began");
					} else if (Input.GetTouch(i).phase == TouchPhase.Ended)
					{
						CheckTouch(Input.GetTouch(i).position, "ended");
					}
				}
			}
		}
		if (Application.platform == RuntimePlatform.WindowsEditor)
		{
			if (Input.GetMouseButtonDown(0))
			{
				CheckTouch(Input.mousePosition, "began");
			}
			
			if (Input.GetMouseButtonUp(0))
			{
				CheckTouch(Input.mousePosition, "ended");
			}
		}
	}


	
	void CheckTouch(Vector3 pos, string phase)
	{
		isActive = (phase == "began"); //If touch detected, buttons are active (purely for WindowsEditor)

		Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
		Vector2 touchPos = new Vector2(wp.x, wp.y);
		Collider2D hit = Physics2D.OverlapPoint(touchPos, ButtonLayer);

		string hitName;//String used to identify object touched
		hitName= hit.transform.gameObject.name; //NullReferenceException

		//Debug.Log ("BC Hit "+hit.transform.gameObject.name+" "+hit+" "+phase); //Debug

		//Jump
		if (ButtonJump.name == hitName && hit && phase == "began")
		{
			//Debug.Log ("BC Jump");
			hero.Jump();
		}

		//Movement Left and Right
		if (ButtonRight.name == hitName && hit && phase == "began"){
			//Debug.Log ("BC Right");
			hero.getInputX(1);
		}
		if (ButtonLeft.name == hitName && hit && phase == "began"){
			//Debug.Log ("BC Left");
			hero.getInputX(-1);
		}
		if ( ( ButtonRight.name == hitName || ButtonLeft.name == hitName ) && hit && phase == "ended"){
			hero.getInputX(0);
		}

		//Spew
		//Contents of this condition should mimic that of the if statement in Player.Update
		if (ButtonSpew.name == hitName && hit && phase == "began"){
			hero.Spew();
			hero.spewing = true;
		}
		//if (ButtonSpew.name == hitName && hit && phase == "ended"){ //Previous: Spew would not be canceled on button release
		if ( ButtonSpew.name == hitName && hit && phase == "ended"){
			hero.CancelSpew();
			hero.spewing = false;
		}

	}

}
