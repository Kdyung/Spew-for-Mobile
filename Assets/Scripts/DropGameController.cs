
using UnityEngine;
using System.Collections;

/**
 * Controller for game state and scores
 * Reference:http://unity3d.com/learn/tutorials/projects/space-shooter/ending-the-game
 * */

public class DropGameController : MonoBehaviour {
	private int score = 100;//current score
	private int totalScore = 0; //combined total of players score
	private int highscore = 100; //highest score player has gotten
	private float spawnTime = 5.0f; //Every 5 seconds (5.0f) 
	private float incrementTime = 1.0f;
	private float minTime = 1.0f;

	public GUIText scoreText;
	public GUIText hiscoreText;

	private bool gameOver;
	private bool restart;
	
	public Vector2 spawnValues;//spawing object height determined by outside
	
	public Player hero;
	public GameObject gameOverZone;

	public GameObject rockObject;
	public GameObject meatObject;

	void Start(){
		highscore = PlayerPrefs.GetInt ("High Score");
		hiscoreText.text = highscore + "";
		gameOver = false;
		//invoke SpawnObjects function repeatedly
		InvokeRepeating("spawnObjects",0.01f,spawnTime); 
	}
	
	void Update()
	{
		//Updates Scores
		scoreText.text = score + ""; //display score
		hiscoreText.text = highscore + "";
		if(score > highscore) //when player dies set highscore = to that score
		{
			highscore = score;
			PlayerPrefs.SetInt("High Score", highscore);
			Debug.Log("High Score is " + highscore );
		}

		if (gameOver) {
			CancelInvoke ("spawnObjects");
		}
	}



	void spawnObjects(){
		//while (!gameOver){
		//note spawn.x is between +5 and -5
			Vector2 spawnPosition = new Vector2 (Random.Range (-5, 5), spawnValues.y);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (rockObject, spawnPosition, spawnRotation);
	}

	void pickUpCollision(GameObject other){
		Debug.Log ("COLLISION DETECTED)");
		//add to players score if he collects a gem
		int displayscore = 10;
			//If the object picked up is meat, 
		//if (other.tag != "TileDestroyer"){ //rough way of checking if it's not a rock
		if (other.name == "meat" || other.name == "meat(Clone)") {
				displayscore = 100;
				//changing the spawntime and making it faster
				if (spawnTime > minTime) {
						spawnTime -= incrementTime;
						//Only way I can find  at the moment to change the spawn time is to cancel and reinvoke
						CancelInvoke ("spawnObjects");
						InvokeRepeating ("spawnObjects", 0.01f, spawnTime); 
				}
		}

		score += displayscore;
		Debug.Log("Your score is " + score);
		Destroy(other.gameObject);
	}
}
