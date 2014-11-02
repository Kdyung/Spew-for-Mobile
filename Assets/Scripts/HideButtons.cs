using UnityEngine;
using System.Collections;

public class HideButtons : MonoBehaviour {
	//If playing on npn android or editor, hide mobile buttons
	// Use this for initialization
	void Start () {
		if (Application.platform == RuntimePlatform.Android||Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Debug.Log("Non-mobile Platfom! Hiding Buttons!");
			//Destroy(GameObject.Find("Buttons"));
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
