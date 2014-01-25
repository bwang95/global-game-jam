using UnityEngine;
using System.Collections;

public class EnemyLimiter : MonoBehaviour {

	Vector3 parentRoom; //This is the POSITION of the parent room, not the object itself.

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setParentRoom(Vector3 v){
		if(parentRoom == null){
			parentRoom = v;
		}
	}

	boolean isWithinBounds(){
		int x = parentRoom.x - transform.position.x;
		int y = parentRoom.y - transform.position.y;
		if(Mathf.Abs(x) <= 5 && Mathf.Abs(y) <= 5){
			return true;
		}else{
			return false;
		}
	}
}
