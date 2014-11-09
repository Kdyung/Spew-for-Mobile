using UnityEngine;
using System.Collections;

/*This Script compiles all of the button functions. This is used 
 * because all the buttons do is access the Player Controller Player.cs
 * anyways so why not just minimize the code.
 * */
public class ButtonController : MonoBehaviour {

	//The following variables are assigned through Inspector
	public LayerMask ButtonLayer; //Layer mask for avoiding collision with non gui

	public GameObject ButtonLeft;
	public GameObject ButtonRight;
	public GameObject ButtonJump;
	public GameObject ButtonSpew;

	public Player hero;//

	public bool isActive;

	// Use this for initialization
	void Start () {
		//Hides the Buttons if playing on the wrong platform
		ButtonLeft.GetComponent<SpriteRenderer>().enabled = ( Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.Android);
		//ButtonLeft.GetComponent<CircleCollider2D>().enabled = ( Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsEditor);
		ButtonRight.GetComponent<SpriteRenderer>().enabled = ( Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.Android);
		ButtonJump.GetComponent<SpriteRenderer>().enabled = ( Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.Android);
		ButtonSpew.GetComponent<SpriteRenderer>().enabled= ( Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.Android);
	}
	
	
	// Update is called once per frame
	void Update()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			if (Input.touchCount > 0)
			{
				if (Input.GetTouch(0).phase == TouchPhase.Began)
				{ 
					CheckTouch(Input.GetTouch(0).position, "began");
				} else if (Input.GetTouch(0).phase == TouchPhase.Ended)
				{
					CheckTouch(Input.GetTouch(0).position, "ended");
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
		isActive = (phase == "began"); //If touch detected, buttons are active

		Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
		Vector2 touchPos = new Vector2(wp.x, wp.y);
		Collider2D hit = Physics2D.OverlapPoint(touchPos, ButtonLayer);

		string hitName = hit.transform.gameObject.name; //String used to identify object touched

		Debug.Log ("BC Hit "+hit.transform.gameObject.name+" "+hit+" "+phase); //Debug

		//Jump
		if (ButtonJump.name == hitName && hit && phase == "began")
		{
			Debug.Log ("BC Jump");
			hero.Jump();
		}

		//Movement Left and Right
		if (ButtonRight.name == hitName && hit && phase == "began"){
			Debug.Log ("BC Right");
			hero.getInputX(1);
		}
		if (ButtonLeft.name == hitName && hit && phase == "began"){
			Debug.Log ("BC Left");
			hero.getInputX(-1);
		}
		if ( (ButtonRight.name == hitName || ButtonLeft.name == hitName) && hit && phase == "ended"){
			hero.getInputX(0);
		}

		//Spew
		if (ButtonSpew.name == hitName && hit && phase == "began")
		{
			hero.Spew();
			hero.spewing = true;
			audio.Play();
		}
		if (ButtonSpew.name == hitName && hit && phase == "ended")
		{
			hero.spewing = false;
		}

	}

}
