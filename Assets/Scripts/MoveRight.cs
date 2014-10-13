using UnityEngine;
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
	private Font goodDog;
    
    // Use this for initialization
    void Start()
    {
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
        
        // Move if button is pressed && stage is not over
        if (moving && bg.transform.position.x > -4.8f)
        {
            for (int i = 0; i < scene.Length; i++)
            {
                if (scene [i] != null)
                {
                    scene [i].transform.position -= moveSpeed;
                }
            }
        }

        // Stage Completed
        if (bg.transform.position.x <= -4.8f && ended == false)
        {
            Alert("complete");
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

    public void Alert(string action)
    {
        ended = true;

        completeText = new GameObject();
        completeText.AddComponent("GUIText");
        completeText.guiText.font = goodDog;
        completeText.guiText.fontSize = 50;
        completeText.guiText.color = new Color(255, 0, 0);
        
        if (action == "complete")
        {
            AudioSource.PlayClipAtPoint(completeSound, transform.position);

            completeText.guiText.text = "Level Complete!";
            completeText.guiText.transform.position = new Vector3(0.24f, 0.88f, 0);

        } else
        {
            completeText.guiText.text = "Game Over";
            completeText.guiText.transform.position = new Vector3(0.36f, 0.88f, 0);
        }

        bg.GetComponent<AudioSource>().Stop();
        
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].renderer.enabled = false;
            Invoke("restart", 2);
        }
    }

    void restart()
    {   
        Application.LoadLevel(Application.loadedLevel);
    }
}