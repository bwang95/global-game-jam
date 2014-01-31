using UnityEngine;
using System.Collections;
using System.Linq;

public class RoomItemController : MonoBehaviour {

	public int toSpawn;
	GameObject[] enemiesWithin;
	public GameObject item;
    bool hasSpawnedItem = false;
    public int numItems;

	// Update is called once per frame
	void Update () {
		if(enemiesWithin.Count(s => s != null) == 0 && !hasSpawnedItem){
			spawnItem();
            hasSpawnedItem = true;
		}
	}

	public void setSpawnItem(int toSpawn){
		this.toSpawn = toSpawn;
	}

	public void setSpawnStatus( GameObject[] enemies){
		enemiesWithin = enemies;
	}

	private void spawnItem(){
		item.GetComponent<ItemController>().setType(toSpawn);
		Instantiate (item, transform.position, Quaternion.identity);
      
	}
}
