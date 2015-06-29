
using UnityEngine;
using System.Collections;

public class sabretooth : MonoBehaviour {
	private Animator animator;
	public Transform target;

	void Start () { 
		animator = this.GetComponent<Animator> ();
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Pressed left click.");
			animator.SetBool ("active", true);
		} else if (Input.GetMouseButtonDown (1)) {
			Debug.Log ("Pressed right click.");
			animator.SetBool ("leaping", true);
		} else if (Input.GetMouseButtonDown (2)){
			Debug.Log ("Pressed middle click.");
			animator.SetBool ("dead", true);
		}
		Vector3 viewPos = Camera.main.WorldToViewportPoint (target.position);
		if (viewPos.x > 0.5F)
			print("sabre is on the right side!");
		else
			print("sabre is on the left side!");
		if ((viewPos.x > 1 || viewPos.x < 0) && (viewPos.y > 1 || viewPos.y < 0)) {
			print("sabre Off camera");
		}
	}


	void destroyObject(){
		Destroy(gameObject);
	}
}
