using UnityEngine;
using System.Collections;

public class TestGridSpawn : MonoBehaviour {

	public GameObject Token;
	public 

	void Start () {
		for(int i = -5; i <= 5; i++){
			for(int n = -5; n <= 5; n++){
				Vector3 locToSpawn = new Vector3(i,n,0);
				Instantiate(Token, locToSpawn, Quaternion.identity);
			}
		}
	}
}
