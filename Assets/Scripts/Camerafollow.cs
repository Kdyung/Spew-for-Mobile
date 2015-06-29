/**Script for camera movement
 * Eventually work out the best movement for camera,
 * currently is fixed on Player.
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
}