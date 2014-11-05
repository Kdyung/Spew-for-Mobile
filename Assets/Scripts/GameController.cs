using UnityEngine;
using System.Collections;

/**
 * Controller for game state and scores
 * Reference:http://unity3d.com/learn/tutorials/projects/space-shooter/ending-the-game
 * */

public class GameController : MonoBehaviour {
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
	/*
	void OnTriggerEnter(other : Collider)
	{
		//add to players score if he collects a gem
		if(other.gameObject.name == "meat" || other.gameObject.name == "meat(Clone)")
		{
			score += 10;
			Debug.Log("Your score is " + score);
			Destroy(other.gameObject); //Destroys Gem after player collects it
		}
	}*/
}
