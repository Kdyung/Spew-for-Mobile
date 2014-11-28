using UnityEngine;
using System.Collections;

/* This is a code for an exit button on mobile only
 * Since this is not related to Player control, it uses its own script.
 * Prototype for a seperate control scheme for menu-related stuff later
 * 
 * */
public class ExitButton : MonoBehaviour
{

		public LayerMask mask;
		public string exit_scene;
		//the scene exited to is assigned in inspector so that button can be reused to go to different menus

		void Start ()
		{
			GetComponent<SpriteRenderer> ().enabled = (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.Android);

		}

		//When called, forcibly changed the scene to a different one (menu)
		void exitGame(){
			Application.LoadLevel (exit_scene);
		}

		// Update is called once per frame
		void Update (){
				if (Input.GetButtonDown ("Quit")) {
						Debug.Log ("Exit Game");
						exitGame ();
				}

				if (Application.platform == RuntimePlatform.Android) {
						if (Input.touchCount > 0) {
								if (Input.GetTouch (0).phase == TouchPhase.Began) { 
										CheckTouch (Input.GetTouch (0).rawPosition, "began");
								} else if (Input.GetTouch (0).phase == TouchPhase.Ended) {
										CheckTouch (Input.GetTouch (0).position, "ended");
								}
						}
				}
				if (Application.platform == RuntimePlatform.WindowsEditor) {
						if (Input.GetMouseButtonDown (0)) {
								CheckTouch (Input.mousePosition, "began");
						}
				
						if (Input.GetMouseButtonUp (0)) {
								CheckTouch (Input.mousePosition, "ended");
						}
				}
		}
		
		//Checks if button is being pressed in Mobile or the Windows Editor
		void CheckTouch (Vector3 pos, string phase)
		{
				Vector3 wp = Camera.main.ScreenToWorldPoint (pos);
				Vector2 touchPos = new Vector2 (wp.x, wp.y);
				Collider2D hit = Physics2D.OverlapPoint (touchPos, mask);

				if (collider2D == hit && hit && phase == "began") {
						Debug.Log ("Exit Game");
						exitGame();
				}
		}
}
