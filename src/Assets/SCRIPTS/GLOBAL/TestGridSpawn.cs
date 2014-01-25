using UnityEngine;
using System.Collections;

public class TestGridSpawn : MonoBehaviour {

	public GameObject centerToken, sideToken, cornerToken;
	public int spacing = 30;
    public int gridSize = 5;

    private Vector3 zVec = new Vector3(0, 0, 1);
    private int loop;
	void Start () {
        loop = gridSize - 1;
		for(int i = -loop; i <= loop; i++){
			for(int n = -loop; n <= loop; n++){
				Vector3 locToSpawn = new Vector3(i*spacing,n*spacing,0);
				Instantiate(centerToken, locToSpawn, Quaternion.identity);
			}
		}

        for(int col = -loop; col <= loop; col++){
            Vector3 colLoc = new Vector3(0, col * spacing, 0);
            Instantiate(sideToken, colLoc, Quaternion.identity);
            colLoc.x = gridSize * spacing;
            Instantiate(sideToken, colLoc, Quaternion.AngleAxis(180, zVec));

            colLoc.y = 0;
            colLoc.x = col * spacing;
            Instantiate(sideToken, colLoc, Quaternion.AngleAxis(90, zVec));
            colLoc.x = col * spacing;
            colLoc.y = gridSize * spacing;
            Instantiate(sideToken, colLoc, Quaternion.AngleAxis(270, zVec));
        }

        Vector3 cornerLoc = new Vector3(-gridSize, -gridSize, 0);
        Instantiate(cornerToken, cornerLoc, Quaternion.identity);

        cornerLoc = new Vector3(-gridSize, gridSize, 0);
        Instantiate(cornerToken, cornerLoc, Quaternion.AngleAxis(90, zVec));

        cornerLoc = new Vector3(gridSize, -gridSize, 0);
        Instantiate(cornerToken, cornerLoc, Quaternion.AngleAxis(180, zVec));
        
        cornerLoc = new Vector3(gridSize, gridSize, 0);
        Instantiate(cornerToken, cornerLoc, Quaternion.AngleAxis(270, zVec));
	}
}
