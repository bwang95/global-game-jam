using UnityEngine;
using System.Collections;

public class TestGridSpawn : MonoBehaviour {

	public GameObject CornerToken;
	public GameObject WallToken;
    public GameObject InteriorToken;
    public int gridSize = 10;
    public int exitX = 0, exitY = 0;
    private Vector3 zVec = new Vector3(0, 0, 1);

public int spacing = 30;

	void Start () {
        int a = gridSize / 2;

        if(!(exitX == 0 || exitX == gridSize || exitY == 0 || exitY == gridSize)){
            print("Invalid exit specified. Randomizing...");
            switch ((int)(Random.value * 4))
            {
                case 0: 
                    exitX = 0;
                    exitY = (int)(Random.value * gridSize);
                    break;
                case 1:
                    exitX = gridSize;
                    exitY = (int)(Random.value * gridSize);
                    break;
                case 2:
                    exitX = (int)(Random.value * gridSize);
                    exitY = 0;
                    break;
                case 3:
                    exitX = (int)(Random.value * gridSize);
                    exitY = gridSize;
                    break;

            }
        }

		for(int i = -a; i <= a; i++){
			for(int n = -a; n <= a; n++){
				Vector3 locToSpawn = new Vector3(i * spacing,n * spacing,0);

                if (i + a == exitX && n + a == exitY){
                    if(Mathf.Abs(exitX) == Mathf.Abs(exitY))
                        Instantiate(WallToken, locToSpawn, Quaternion.AngleAxis((int)(Random.value * 4) * 90 ,zVec));
                    else
                        Instantiate(InteriorToken, locToSpawn, Quaternion.identity);

                    print("Inserting exit");
                }
                else if (i == -a && n == -a)
                    Instantiate(CornerToken, locToSpawn, Quaternion.AngleAxis(90, zVec));
                else if (i == a && n == -a)
                    Instantiate(CornerToken, locToSpawn, Quaternion.AngleAxis(180, zVec));
                else if (i == -a && n == a)
                    Instantiate(CornerToken, locToSpawn, Quaternion.identity);
                else if (i == a && n == a)
                    Instantiate(CornerToken, locToSpawn, Quaternion.AngleAxis(270, zVec));


                else if (i == -a)
                    Instantiate(WallToken, locToSpawn, Quaternion.identity);
                else if (i == a)
                    Instantiate(WallToken, locToSpawn, Quaternion.AngleAxis(180, zVec));
                else if (n == -a)
                    Instantiate(WallToken, locToSpawn, Quaternion.AngleAxis(90, zVec));
                else if (n == a)
                    Instantiate(WallToken, locToSpawn, Quaternion.AngleAxis(270, zVec));
                else Instantiate(InteriorToken, locToSpawn, Quaternion.identity);
			}
		}
	}

}
