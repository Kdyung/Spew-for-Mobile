
using UnityEngine;
using System.Collections;

/**
 * Controller for game state and scores
 * Reference:http://unity3d.com/learn/tutorials/projects/space-shooter/ending-the-game
 * */

public class DropGameController : MonoBehaviour {
	private int score = 100;//current score
	private int highscore = 100; //highest score player has gotten
	private float spawnTime = 5.0f; //Every 5 seconds (5.0f) 
	private float incrementTime = 1.0f;
	private float minTime = 1.0f;

	//GUIText for displaying the score.
	//Note: for some reason, transform must be (0,1,0) for GUIText to show up
	public GUIText scoreText; 
	public GUIText hiscoreText;

	private bool gameOver;
	private bool restart;
	
	public Vector2 spawnValues;//spawing object height determined by outside
	
	public Player hero;
	public GameObject gameOverZone;

	public GameObject rockObject;
	public GameObject meatObject;
	private int rockCount = 0;
	void Start(){
		highscore = PlayerPrefs.GetInt ("High Score");
		hiscoreText.text = highscore + "";
		gameOver = false;
		//invoke SpawnObjects function repeatedly
		InvokeRepeating("spawnObjects",0.01f,spawnTime); 

		if (Application.platform == RuntimePlatform.Android) {
			scoreText.fontSize = 40;
			hiscoreText.fontSize = 30;
		}
		scoreText.text = "Score: " + score;
		hiscoreText.text = "High Score: " + score;
	}
	
	void Update()
	{
		//Updates Scores
		if(score > highscore) //when player dies set highscore = to that score
		{
			highscore = score;
			PlayerPrefs.SetInt("High Score", highscore);
			Debug.Log("High Score is " + highscore );
		}
		updateScores ();

		if (gameOver) {
			CancelInvoke ("spawnObjects");
		}
	}

	void updateScores(){
		scoreText.text = "Score: " + score;
		hiscoreText.text = "High Score: " + score;
		//Debug.Log (scoreText.text);
	}

	void getGameOver(){
		gameOver = true;
		Application.LoadLevel ("mainmenu");
	}

	void spawnObjects(){
		//while (!gameOver){
		//note spawn.x is between +5 and -5
		Vector2 spawnPosition = new Vector2 (Random.Range (-5, 5), spawnValues.y);
		Quaternion spawnRotation = Quaternion.identity;
		//Every 10-20 rocks drop a meat items for extra score and speed up drop rate
		if (rockCount > 20) {
			Instantiate (meatObject, spawnPosition, spawnRotation);
			rockCount = 0;
		} else {
			Instantiate (rockObject, spawnPosition, spawnRotation);
			rockCount++;
		}
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
