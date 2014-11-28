using UnityEngine;
using System.Collections;

public class DropGameMenu : MonoBehaviour {
	private string playgame = "Play Game";
	private string exitgame = "Go to Main Menu";
	private string resetscore = "Reset High Score";
	public GUIText hiscoreText;
	public GUIText instructions;
	
	// Use this for initialization
	void Start () {
		
		OnGUI ();
	}
	
	void OnGUI () {
		hiscoreText.text = "High Score: "+PlayerPrefs.GetInt ("High Score");
		instructions.text = 
			"Catch all falling objects\n" +
			"and get a high score! Don't\n" +
			"let the ice break!";
		if (Application.platform == RuntimePlatform.Android) {
			GUIStyle style = new GUIStyle(GUI.skin.button);
			style.fontSize = 20;
			
			// Make a background box (prev(10,10,100,90)
			//GUI.Box (new Rect (0, 0, 300, 400), "Main Menu", style);
			// Make the first button. prev(20,40,80,20)
			if (GUI.Button (new Rect (500, 090, 260, 90), playgame, style) ) {
				Application.LoadLevel ("dropgame");
			}
			if (GUI.Button (new Rect (500, 290, 260, 50), resetscore, style)) {
				PlayerPrefs.SetInt("High Score", 0);
				hiscoreText.text = "High Score: "+PlayerPrefs.GetInt ("High Score");
			}
			if (GUI.Button (new Rect (500, 350, 260, 90), exitgame, style)) {
				Application.LoadLevel ("mainmenu");
			}
		} else {
			// Make a background box (prev(10,10,100,90)

			if (GUI.Button (new Rect (400, 60, 120, 40), playgame) ) {
				Application.LoadLevel ("dropgame");
			}
			if (GUI.Button (new Rect (400, 120, 120, 40), resetscore)) {
				PlayerPrefs.SetInt("High Score", 0);
				hiscoreText.text = "High Score: "+PlayerPrefs.GetInt ("High Score");
				
			}
			if (GUI.Button (new Rect (400, 170, 120, 40), exitgame)) {
				Application.LoadLevel ("mainmenu");
			}
		}
	}
	//resizes image to full screen (ruins ratio)
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
