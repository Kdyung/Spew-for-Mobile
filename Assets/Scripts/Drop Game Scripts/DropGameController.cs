
using UnityEngine;
using System.Collections;

/**
 * Controller for game state and scores
 * Reference:http://unity3d.com/learn/tutorials/projects/space-shooter/ending-the-game
 * */

public class DropGameController : MonoBehaviour {
	private int score = 100;//current score
	private int highscore = 100; //highest score player has gotten
	private float spawnTime = 3.0f; //Every 5 seconds (5.0f) 
	private float incrementTime = 1.0f;
	private float minTime = 0.5f;
	private int rockcount_max = 10;
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
		gameOver = false;

		//invoke SpawnObjects function repeatedly
		InvokeRepeating("spawnObjects",0.01f,spawnTime); 

		if (Application.platform == RuntimePlatform.Android) {
			scoreText.fontSize = 40;
			hiscoreText.fontSize = 30;
		}
		scoreText.text = "Score: " + score;
		hiscoreText.text = "High Score: " + PlayerPrefs.GetInt ("High Score");
	}
	
	void Update()
	{
		//Updates Scores
		updateScores ();

		if (gameOver) {
			CancelInvoke ("spawnObjects");
		}
	}

	void updateScores(){
		if(score > highscore){
			highscore = score;
			PlayerPrefs.SetInt("High Score", highscore);
			//Debug.Log("High Score is " + highscore );
		}
		scoreText.text = "Score: " + score;
		hiscoreText.text = "High Score: " + highscore;
		//Debug.Log (scoreText.text);
	}

	void getGameOver(){
		gameOver = true;
		PlayerPrefs.SetInt ("Score",score);
		Application.LoadLevel ("dropgameover");

	}

	void spawnObjects(){
		//while (!gameOver){
		//note spawn.x is between +5 and -5
		Vector2 spawnPosition = new Vector2 (Random.Range (-5, 5), spawnValues.y);
		Quaternion spawnRotation = Quaternion.identity;
		//Every 10-20 rocks drop a meat items for extra score and speed up drop rate
		if (rockCount > rockcount_max) {
			Instantiate (meatObject, spawnPosition, spawnRotation);
			rockCount = 0;
		} else {
			Instantiate (rockObject, spawnPosition, spawnRotation);
			rockCount++;
		}
	}

	//This is a function called by DropGamePickUp to process score incrementing and other stuff 
	void pickUpCollision(GameObject other){
		//Debug.Log ("COLLISION DETECTED)");

		int addscore = 10;
		//If the object picked up is meat make rocks drop faster
		if (other.name == meatObject.name || other.name == meatObject.name+"(Clone)") {
				addscore = 100;
				//changing the spawntime and making it faster once a meat object is picked up
				if (spawnTime > minTime) {
						spawnTime -= incrementTime;
						if (spawnTime < minTime){
							spawnTime = minTime;
						}
						//Only way I can find  at the moment to change the spawn time is to cancel and reinvoke
						CancelInvoke ("spawnObjects");
						InvokeRepeating ("spawnObjects", 0.01f, spawnTime); 
				}
		}

		score += addscore;
		Destroy(other.gameObject);
	}
}
