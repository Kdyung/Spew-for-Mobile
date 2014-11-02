using UnityEngine;
using System.Collections;

public class Spew : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Hide and disable button if not on mobile
		GetComponent<SpriteRenderer>().enabled = (  Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.Android);
		collider.enabled = ( Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsEditor);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
