﻿using UnityEngine;
using System.Collections;
using System.Linq;

public class RoomItemController : MonoBehaviour {

	int toSpawn;
	GameObject[] enemiesWithin;
	public GameObject item;

	// Update is called once per frame
	void Update () {
		if(enemiesWithin.Count(s => s != null) == 0){
			spawnItem();
		}
	}

	public void setSpawnItem(int toSpawn){
		this.toSpawn = toSpawn;
	}

	public void setSpawnStatus( GameObject[] enemies){
		enemiesWithin = enemies;
	}

	private void spawnItem(){
		Instantiate (item, transform.position, Quaternion.identity);
	}
}
