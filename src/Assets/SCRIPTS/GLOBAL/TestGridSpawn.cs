using UnityEngine;
using System.Collections;

public class TestGridSpawn : MonoBehaviour {

	public GameObject CornerToken;
	public GameObject WallToken;
    public GameObject InteriorToken;
    private Vector3 zVec = new Vector3(0, 0, 1);

public int spacing = 30;

	void Start () {
		for(int i = -5; i <= 5; i++){
			for(int n = -5; n <= 5; n++){
				Vector3 locToSpawn = new Vector3(i * spacing,n * spacing,0);
                if (i == -5 && n == -5)
                    Instantiate(CornerToken, locToSpawn, Quaternion.AngleAxis(90, zVec));
                else if (i == 5 && n == -5)
                    Instantiate(CornerToken, locToSpawn, Quaternion.AngleAxis(180, zVec));
                else if (i == -5 && n == 5)
                    Instantiate(CornerToken, locToSpawn, Quaternion.identity);
                else if (i == 5 && n == 5)
                    Instantiate(CornerToken, locToSpawn, Quaternion.AngleAxis(270, zVec));


				else if (i == -5)
					Instantiate(WallToken, locToSpawn, Quaternion.identity);
				else if (i == 5)
					Instantiate(WallToken, locToSpawn, Quaternion.AngleAxis(180, zVec));
				else if (n == -5)
                    Instantiate(WallToken, locToSpawn, Quaternion.AngleAxis(90, zVec));
				else if (n == 5)
                    Instantiate(WallToken, locToSpawn, Quaternion.AngleAxis(270, zVec));
				else Instantiate(InteriorToken, locToSpawn, Quaternion.identity);
			}
		}
	}

}
