using UnityEngine;
using System.Collections;

public class RoomSpawnController : MonoBehaviour {


	public Vector3 spawnOrigin;
	public GameObject[] toSpawn;


	void Start () {
		spawnOrigin = transform.position;
		spawn (0);
	}

	GameObject SpawnObject (GameObject g, Vector3 relativePosition){
		Vector3 spawnPosition = spawnOrigin + relativePosition;
		GameObject clone = (GameObject) Instantiate(g, spawnPosition, Quaternion.identity);
		EnemyLimiter s = (EnemyLimiter) clone.GetComponent(typeof(EnemyLimiter));
		s.setParentRoom(spawnOrigin);
		return clone;
	}

	void spawn(int style){
		int nToSpawn = Mathf.CeilToInt(Random.Range(0,5)) + 1;
		GameObject[] inhabitants = new GameObject[nToSpawn];

		for(int i = 0; i < nToSpawn; i++){
			Vector3 pos = Random.insideUnitCircle * 4;
			inhabitants[i] = SpawnObject(toSpawn[0], pos);
		}

		RoomItemController s = gameObject.GetComponent<RoomItemController>();
		s.setSpawnStatus(inhabitants);
	}
}
