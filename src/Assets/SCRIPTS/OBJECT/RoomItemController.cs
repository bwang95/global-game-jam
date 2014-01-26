using UnityEngine;
using System.Collections;

public class RoomItemController : MonoBehaviour {

	int toSpawn;
	GameObject[] enemiesWithin;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setSpawnItem(int toSpawn){
		this.toSpawn = toSpawn;
	}

	public void setSpawnStatus( GameObject[] enemies){
		enemiesWithin = enemies;
	}
}
