using UnityEngine;
using System.Collections;

public class RoomSpawnController : MonoBehaviour {


	Vector3 spawnOrigin;
	public GameObject[] toSpawn;


	void Start () {
		spawnOrigin = transform.position;
		spawn (0);
	}

	void SpawnObject (GameObject g, Vector3 relativePosition){
		Vector3 spawnPosition = relativePosition + relativePosition;
		Instantiate(g, spawnPosition, Quaternion.identity);
		EnemyLimiter s = (EnemyLimiter) g.GetComponent(typeof(EnemyLimiter));
		s.setParentRoom(spawnOrigin);
	}

	void spawn(int style){
		switch(style){
		case 1:
			break;
		}
		for(int i = 0; i < Mathf.CeilToInt(Random.Range(0,5)); i++){
			Vector3 pos = Random.insideUnitCircle * 5;
			SpawnObject(toSpawn[0], pos);
		}
	}


}
