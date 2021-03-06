﻿using UnityEngine;
using System.Collections;

public class EnemyLimiter : MonoBehaviour {

	public Vector3 parentRoom; //This is the POSITION of the parent room, not the object itself.
	GameObject player;


	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setParentRoom(Vector3 v){
			parentRoom = v;
	}

	public bool isWithinBounds(){
		float x = parentRoom.x - transform.position.x;
		float y = parentRoom.y - transform.position.y;
		if(Mathf.Abs(x) <= 15 && Mathf.Abs(y) <= 15){
			return true;
		}else{
			return false;
		}
	}

	public bool playerWithinBounds(){
		float x = parentRoom.x - player.transform.position.x;
		float y = parentRoom.y - player.transform.position.y;
		if(Mathf.Abs(x) <= 15 && Mathf.Abs(y) <= 15){
			return true;
		}else{
			return false;
		}
	}

	public Vector2 randPoint(){
				float x = parentRoom.x + Random.value * 28 - 13;
				float y = parentRoom.y + Random.value * 28 - 13;
				return new Vector2 (x, y);
		}
}
