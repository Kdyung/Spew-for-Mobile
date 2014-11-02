using UnityEngine;
using System.Collections;

public class MoveLeft : MonoBehaviour
{
	//public Vector3 moveSpeed = new Vector3();
	public bool isDown;
	public Player hero;
	
	
	// Use this for initialization
	void Start()
	{
		//Hide and disable button if not on mobile
		GetComponent<SpriteRenderer>().enabled = (  Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.Android);
		GetComponent<CircleCollider2D>().enabled = ( Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsEditor);
		
		
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
		
		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
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
		Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
		Vector2 touchPos = new Vector2(wp.x, wp.y);
		Collider2D hit = Physics2D.OverlapPoint(touchPos);

		Debug.Log(hit.transform.gameObject.name);
		if (collider2D == hit && hit && phase == "began")
		{
			isDown = true;
			Debug.Log("Left");
			hero.getInputX(-1);
		}
		
		if (collider2D == hit && hit && phase == "ended")
		{
			isDown = false;
			hero.getInputX(0);
		}
	}
}