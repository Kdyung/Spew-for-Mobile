using UnityEngine;
using System.Collections;

public class DropGameOver : MonoBehaviour {
	int score;
	int hiscore;
	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetInt ("Score");
		hiscore = PlayerPrefs.GetInt ("High Score");
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnGUI(){
		//Display score and game over message
		if (Application.platform == RuntimePlatform.Android) {
			GUIStyle buttonstyle = new GUIStyle(GUI.skin.button);
			buttonstyle.fontSize = 35;
			GUIStyle labelstyle = new GUIStyle(GUI.skin.label);
			labelstyle.fontSize = 40;
			GUIStyle scorestyle = new GUIStyle(GUI.skin.label);
			scorestyle.fontSize = 30;

			GUI.Label ( new Rect (Screen.width/2 -100, 20, 300, 40), "Game Over" ,labelstyle);

			GUI.Label ( new Rect (Screen.width/2 -100, 80, 300, 40), "Score: " + score, scorestyle);
			GUI.Label ( new Rect (Screen.width/2 -100, 100, 300, 40), "High Score: " + hiscore, scorestyle);

			if (GUI.Button (new Rect (Screen.width/2 + 200, 200, 300, 90), "Back to Menu", buttonstyle)) {
				Application.LoadLevel ("dropgamemenu");
			}
		} else {
			GUI.Label ( new Rect (Screen.width/2 -40, 40, 300, 40), "Game Over" );
			GUI.Label ( new Rect (Screen.width/2 -40, 60, 300, 40), "Score: " + score );
			GUI.Label ( new Rect (Screen.width/2 -40, 80, 300, 40), "High Score: " + hiscore );
			if (GUI.Button (new Rect (Screen.width/2 + 60, 170, 300, 40), "Back to Menu")) {
				Application.LoadLevel ("dropgamemenu");
			}
		}
	}
}
