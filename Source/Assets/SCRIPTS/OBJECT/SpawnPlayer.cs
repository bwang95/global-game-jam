using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {

    public GameObject playerPrefab;
	public GameObject shadow;

	void Start () {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
		Instantiate(shadow, transform.position, Quaternion.identity);
	}

}
