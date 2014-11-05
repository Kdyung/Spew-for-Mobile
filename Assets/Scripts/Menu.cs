using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
		OnGUI ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI () {
		// Make a background box (prev(10,10,100,90)
		GUI.Box(new Rect(10,10,100,90), "Main Menu");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,40,80,20), "Drop Game")) {
			Application.LoadLevel("dropgame");
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(20,70,80,20), "Exit Game")) {
			Application.Quit ();
		}
	}
	
	void Resize()
	{
		SpriteRenderer sr=GetComponent<SpriteRenderer>();
		if(sr==null) return;
		transform.localScale=new Vector3(1,1,1);
		float width=sr.sprite.bounds.size.x;
		float height=sr.sprite.bounds.size.y;
		float worldScreenHeight=Camera.main.orthographicSize*2f;
		float worldScreenWidth=worldScreenHeight/Screen.height*Screen.width;
		Vector3 xWidth = transform.localScale;
		xWidth.x=worldScreenWidth / width;
		transform.localScale=xWidth;
		//transform.localScale.x = worldScreenWidth / width;
		Vector3 yHeight = transform.localScale;
		yHeight.y=worldScreenHeight / height;
		transform.localScale=yHeight;
		//transform.localScale.y = worldScreenHeight / height;
	}
	
	
	
}
