/**Script for camera movement
 * Fixes camera on Player
 * @TODO Create camera effects and optimize for gameplay 
 * @TODO Resize camera for different platforms
 * **/
using UnityEngine;
using System.Collections;
     
public class Camerafollow : MonoBehaviour{
		 
		private Transform player;

		void Start (){
				player = GameObject.Find ("Player").transform;
		}
		 
		void Update (){
				Vector3 playerpos = player.position;
				playerpos.z = transform.position.z;
				transform.position = playerpos;
		}

		IEnumerator shakeCamera(float duration, float magnitude){
			//@Todo: implement and edit for needs
			//source: http://unitytipsandtricks.blogspot.co.uk/2013/05/camera-shake.html
			float elapsed = 0.0f;
			Vector3 originalCamPos = Camera.main.transform.position;
			while (elapsed < duration) {
				elapsed += Time.deltaTime;          
				float percentComplete = elapsed / duration;         
				float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);
				// map value to [-1, 1]
				float x = Random.value * 2.0f - 1.0f;
				float y = Random.value * 2.0f - 1.0f;
				x *= magnitude * damper;
				y *= magnitude * damper;
				Camera.main.transform.position = new Vector3(x, y, originalCamPos.z);
				yield return null;
			}
			Camera.main.transform.position = originalCamPos;
		}
}