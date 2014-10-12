using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{
	public float jumpForce;
	private GameObject hero; //used to reference our character (hero) on the scene
	
	// Use this for initialization
	void Start()
	{
		hero = GameObject.Find("Player"); //gets the hero game object
	}
	
	// Update is called once per frame
	void Update()
	{
		/* Check if the user is touching the button on the device */
		
		if (Application.platform == RuntimePlatform.Android)
		{
			if (Input.touchCount > 0)
			{
				if (Input.GetTouch(0).phase == TouchPhase.Began)
				{
					CheckTouch(Input.GetTouch(0).position, "began"); // function created below
				} else if (Input.GetTouch(0).phase == TouchPhase.Ended)
				{
					CheckTouch(Input.GetTouch(0).position, "ended");
				}
			}
		}
		
		/* Check if the user is touching the button on the Editor, change OSXEditor value if you are on Windows */
		
		if (Application.platform == RuntimePlatform.OSXEditor)
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
		/* Get the screen point where the user is touching */
		Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
		Vector2 touchPos = new Vector2(wp.x, wp.y);
		Collider2D hit = Physics2D.OverlapPoint(touchPos);
		
		/* if button is touched... */
		
		if (hit.gameObject.name == "JumpButton" && hit && phase == "began")
		{
			hero.rigidbody2D.AddForce(new Vector2(0f, jumpForce)); //Add jump force to hero
			audio.Play(); // play audio attached to this game object (jump sound)
		}
	}
}