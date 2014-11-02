﻿using UnityEngine;
using System.Collections;

public class MoveRight : MonoBehaviour
{
    public Vector3 moveSpeed = new Vector3();

	public Player hero;


	// Use this for initialization
    void Start()
    {
		//Hide and disable button if not on mobile
		GetComponent<SpriteRenderer>().enabled = (  Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.Android);
		collider.enabled = ( Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsEditor);


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
        Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
        Vector2 touchPos = new Vector2(wp.x, wp.y);
        Collider2D hit = Physics2D.OverlapPoint(touchPos);
		while (hit.gameObject.name == "button_right" && hit && phase == "began") {
			hero.moveRight ();
		}

		if (hit.gameObject.name == "button_right" && hit && phase == "began")
        {
			Debug.Log("Right");
			hero.moveRight ();
        }
                
        if (hit.gameObject.name == "button_right" && hit && phase == "ended")
        {

        }
    }
}