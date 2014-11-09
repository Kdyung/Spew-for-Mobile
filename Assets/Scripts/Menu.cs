using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	
	// Use this for initialization
	void Start () {
		//Resize ();
		OnGUI ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI () {
		if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsEditor) {
			GUIStyle style = new GUIStyle(GUI.skin.button);
			style.fontSize = 45;

			// Make a background box (prev(10,10,100,90)
			//GUI.Box (new Rect (0, 0, 300, 400), "Main Menu", style);
			// Make the first button. prev(20,40,80,20)
			if (GUI.Button (new Rect (50, 190, 260, 90), "Play Game (unavailable)", style) ) {
				//Application.LoadLevel ("dropgame");
			}
			if (GUI.Button (new Rect (50, 290, 260, 90), "Falling Object Game", style) ) {
					Application.LoadLevel ("dropgame");
			}
		
			// Make the second button.
			if (GUI.Button (new Rect (50, 390, 260, 90), "Exit", style)) {
					Application.Quit ();
			}
		} else {
			// Make a background box (prev(10,10,100,90)
			GUI.Box (new Rect (10, 40, 100, 90), "Main Menu");

			if (GUI.Button (new Rect (20, 60, 80, 20), "Play Game (unavailable)") ) {
				//Application.LoadLevel ("dropgame");
			}
			// Make the first button. prev(20,40,80,20)
			if (GUI.Button (new Rect (20, 90, 80, 20), "Falling Object Game")) {
					Application.LoadLevel ("dropgame");
			}
			
			// Make the second button.
			if (GUI.Button (new Rect (20, 120, 80, 20), "Exit Game")) {
					Application.Quit ();
			}
		}
	}
		
	void Resize(){
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
