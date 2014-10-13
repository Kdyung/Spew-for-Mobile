using UnityEngine;
using System.Collections;

public class MoveLeft : MonoBehaviour
{
    public Vector3 moveSpeed = new Vector3();
    private bool moving = false;
    private GameObject[] scene;
    private GameObject bg;
    
    // Use this for initialization
    void Start()
    {
        scene = GameObject.FindGameObjectsWithTag("Moveable");
        bg = GameObject.Find("Platforms");
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
        
        // Move if button is pressed
        if (moving && bg.transform.position.x < 4.82f)
        {
            for (int i = 0; i < scene.Length; i++)
            {
                if (scene [i] != null)
                {
                    scene [i].transform.position += moveSpeed;
                }
            }
        }
    }
    
    void CheckTouch(Vector3 pos, string phase)
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
        Vector2 touchPos = new Vector2(wp.x, wp.y);
        Collider2D hit = Physics2D.OverlapPoint(touchPos);
        
        if (hit.gameObject.name == "LeftButton" && hit && phase == "began")
        {
            moving = true;
        }
        
        if (hit.gameObject.name == "LeftButton" && hit && phase == "ended")
        {
            moving = false;
        }
    } 
}