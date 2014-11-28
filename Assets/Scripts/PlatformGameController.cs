using UnityEngine;
using System.Collections;

/**
 * Controller for game state and scores
 * Reference:http://unity3d.com/learn/tutorials/projects/space-shooter/ending-the-game
 * */

public class PlatformGameController : MonoBehaviour {
	private int highscore = 0; //highest score player has gotten
	
	public GUIText scoreText;
	
	private bool gameOver;
	private bool restart;
	private int score;//current score
	
	public Player hero;
	
	void Start(){
		highscore = PlayerPrefs.GetInt ("High Score");
	}
	
	void Update()
	{
		scoreText.text = score + ""; //display score
		if(score > highscore) //when player dies set highscore = to that score
		{
			highscore = score;
			PlayerPrefs.SetInt("High Score", highscore);
			Debug.Log("High Score is " + highscore );
		}
	}
}
