using UnityEngine;
using System.Collections;

public class MeltableController : MonoBehaviour {
	//private bool melting;
	// Use this for initialization
	void Start () {
		//melting = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void destroyTile(){
				DestroyObject (gameObject);
		}
}
