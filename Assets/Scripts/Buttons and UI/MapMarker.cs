using UnityEngine;
using System.Collections;

public class MapMarker : MonoBehaviour {
	public string level;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void loadLevel(){
		Application.LoadLevel (level);
	}
}
