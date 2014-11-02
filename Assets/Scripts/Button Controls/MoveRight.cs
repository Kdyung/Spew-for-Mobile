﻿using UnityEngine;
using System.Collections;

public class MoveRight : MonoBehaviour
{
    public Vector3 moveSpeed = new Vector3();
    private bool moving = false;
    private GameObject[] scene;
    private GameObject bg;
    public AudioClip completeSound;
    private GameObject[] buttons;
    private GameObject completeText;
    private bool ended = false;
    
    // Use this for initialization
    void Start()
    {
		//Hide and disable button if not on mobile
		GetComponent<SpriteRenderer>().enabled = (  Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.Android);
		collider.enabled = ( Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsEditor);


		scene = GameObject.FindGameObjectsWithTag("Moveable");
        bg = GameObject.Find("Background");
        buttons = GameObject.FindGameObjectsWithTag("Buttons");
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
            
        if (hit.gameObject.name == "RightButton" && hit && phase == "began")
        {
            moving = true;
        }
                
        if (hit.gameObject.name == "RightButton" && hit && phase == "ended")
        {
            moving = false;
        }
    }
}