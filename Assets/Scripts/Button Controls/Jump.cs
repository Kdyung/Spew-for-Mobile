using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{
    public float jumpForce;
    //private GameObject hero;
    // Use this for initialization

	public Player hero; //Variable for accessing Player.cs scripts

    void Start()
    {
        //hero = GameObject.Find("Player");

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
        
        if (hit.gameObject.name == "button_jump" && hit && phase == "began")
        {
			Debug.Log("Jumping");
			hero.Jump();
            audio.Play();
        }
    }
}