using UnityEngine;
using System.Collections;

public class TestGridSpawn : MonoBehaviour {

	public GameObject Token;
	public GameObject WallToken;

public int spacing = 30;

	void Start () {
		for(int i = -5; i <= 5; i++){
			for(int n = -5; n <= 5; n++){
				Vector3 locToSpawn = new Vector3(i*spacing,n*spacing,0);
				if(i == -5){
					Instantiate(WallToken, locToSpawn, Quaternion.identity);
				}
				if (i == 5){
					Instantiate(WallToken, locToSpawn, new Quaternion(0,0,180,0));
				}
				if (n == -5){
					Instantiate(WallToken, locToSpawn, new Quaternion(0,0,90,0));
				}
				if (n == 5){
					Instantiate(WallToken, locToSpawn, new Quaternion(0,0,270,0));
				}

				Instantiate(Token, locToSpawn, Quaternion.identity);
			}
		}
	}

}
