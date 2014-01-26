using UnityEngine;
using System.Collections;

public class TrackPlayer : MonoBehaviour {

	GameObject player;
	Vector3 offset = new Vector3(-4,-4,0);
	
	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
	}
	void Update () {
		transform.position = player.transform.position + offset;
	}
}
