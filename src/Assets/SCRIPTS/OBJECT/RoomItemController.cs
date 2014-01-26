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

	public void setSpawnStatus(int toSpawn, GameObject[] enemies){
		this.toSpawn = toSpawn;
		enemiesWithin = enemies;
	}
}
