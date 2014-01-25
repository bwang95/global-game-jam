using UnityEngine;
using System.Collections;

public class GenericEnemyBehavior : MonoBehaviour {

	enum Direction {UP, DOWN, LEFT, RIGHT};

	private int speed = 5;
	Direction dir;

	// Use this for initialization
	void Start () {
		print ((int)Direction.UP);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
