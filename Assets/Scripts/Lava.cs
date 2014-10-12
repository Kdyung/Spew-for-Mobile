using UnityEngine;
using System.Collections;

public class Lava : MonoBehaviour {
	public Transform lavaPrefab;
	public float lavaCooldown;
	public float lavaRate = 0.25f;

	// Use this for initialization
	void Start () {
		lavaCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (lavaCooldown > 0) {
			lavaCooldown -= Time.deltaTime;
		}
	}

	public void shootLava() {
		if (canShootLava()) {
			lavaCooldown = lavaRate;
				}

	}

	public bool canShootLava () {
		if (lavaCooldown <= 0f) {
			return true;
		}
		else {
			return false;
		}
	}
}
