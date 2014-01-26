using UnityEngine;
using System.Collections;

public class RoomSpawnController : MonoBehaviour {


	public Vector3 spawnOrigin;
	public GameObject[] toSpawn;


	void Start () {
		spawnOrigin = transform.position;
		spawn (0);
	}

	void SpawnObject (GameObject g, Vector3 relativePosition){
		Vector3 spawnPosition = spawnOrigin + relativePosition;
		GameObject clone = (GameObject) Instantiate(g, spawnPosition, Quaternion.identity);
		EnemyLimiter s = (EnemyLimiter) clone.GetComponent(typeof(EnemyLimiter));
		s.setParentRoom(spawnOrigin);
	}

	void spawn(int style){
		switch(style){
		case 1:
			break;
		}
		for(int i = 0; i < Mathf.CeilToInt(Random.Range(0,5) + 1); i++){
			Vector3 pos = Random.insideUnitCircle * 5;
			SpawnObject(toSpawn[0], pos);
		}
	}


}
