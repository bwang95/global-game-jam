using UnityEngine;
using System.Collections;

public class RoomObjective : MonoBehaviour {

	GameObject[] allRooms;
	void Start () {
		allRooms = GameObject.FindGameObjectsWithTag("Room");
		int no = allRooms.Length;

	}

}
