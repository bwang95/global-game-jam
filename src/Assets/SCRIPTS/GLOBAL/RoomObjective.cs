using UnityEngine;
using System.Collections;

public class RoomObjective : MonoBehaviour {

	enum items {nothing, sgcard, wizcard, aegis};

	GameObject[] allRooms;
	void Start () {
		allRooms = GameObject.FindGameObjectsWithTag("Room");
		int no = allRooms.Length;
		int a = (int) Mathf.Floor(Random.Range(0, no));
		int b = a;
		while (a == b){
			b = (int) Mathf.Floor(Random.Range(0, no));
		}

		for (int n = 0; n < allRooms.Length; n++){
			if(n == a){
				getController(allRooms[n]).setSpawnItem(1);
			}else if(n == b){
				getController(allRooms[n]).setSpawnItem(2);
			}else{
				getController(allRooms[n]).setSpawnItem(Mathf.FloorToInt(Random.Range(3,Enum.GetNames(typeof(items)).length)));
			}
		}
	}

	RoomItemController getController(GameObject room){
		return room.GetComponent(typeof(RoomItemController));
	}

}
