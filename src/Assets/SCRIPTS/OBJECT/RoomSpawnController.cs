using UnityEngine;
using System.Collections;

public class RoomSpawnController : MonoBehaviour {

	GameObject room = transform.parent.gameObject;
	Vector3 spawnOrigin;
	public GameObject[] toSpawn;

	void Start () {
		spawnOrigin = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnObject (GameObject g, Vector3 relativePosition){
		Vector3 spawnPosition = relativePosition + relativePosition;
		Instantiate(g, spawnPosition, Quaternion.identity);
		EnemyLimiter s = g.GetComponent(typeof(EnemyLimiter));
		s.setParentRoom(spawnOrigin);
	}
}
