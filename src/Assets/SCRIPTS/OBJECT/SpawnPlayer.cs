using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {

    public GameObject playerPrefab;

	void Start () {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
	}

}
