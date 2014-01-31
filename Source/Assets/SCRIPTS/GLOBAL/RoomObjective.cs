using UnityEngine;
using System.Collections;

public class RoomObjective : MonoBehaviour {

	enum items {nothing, wizcard, sgcard, aegis, iblade, ihilt, hglass, dice};
	bool hasRun = false;

	GameObject[] allRooms;
	void Update () {
		//print (hasRun);
		if(!hasRun){
			allRooms = GameObject.FindGameObjectsWithTag("Room");
			print(allRooms.Length);
			if(allRooms.Length > 0){
				int no = allRooms.Length;
				int a = (int) Mathf.Floor(Random.Range(1, no));
				print ("a = " + a);
				int b = a;
				while (a == b){
					b = (int) Mathf.Floor(Random.Range(0, no));
				}
				print ("b = " + b);

				for (int n = 0; n < allRooms.Length; n++){
					if(getController(allRooms[n]) == null){
						if( n == a){
							a++;
						}else if (n == b){
							b++;
						}
						if(a == b){
							a++;
						}
					}else if(n == a){
						getController(allRooms[n]).setSpawnItem(1);
					}else if(n == b){
						getController(allRooms[n]).setSpawnItem(2);
					}else{
						getController(allRooms[n]).setSpawnItem(Mathf.FloorToInt(Random.Range(3,items.GetNames(typeof(items)).Length)));
					}
				}
				hasRun = true;
			}
		}
	}

	RoomItemController getController(GameObject room){
		return room.GetComponent<RoomItemController>();
	}

}
