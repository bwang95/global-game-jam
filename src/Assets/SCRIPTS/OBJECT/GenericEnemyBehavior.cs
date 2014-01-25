using UnityEngine;
using System.Collections;

public class GenericEnemyBehavior : MonoBehaviour {

	public GameObject player;

	//						  	   0    90   180
	private double[] chances = {0.50, 0.35, 0.15};
	private bool chasing = false;
	private double duration = 0.0;
	private static Random r = new Random();
	private const int SPEED = 5;
	private EnemyLimiter s;
	
	void Start(){
		s = (EnemyLimiter) transform.parent.GetComponent(typeof(EnemyLimiter));
	}
	void Update () {
		//transform.position.x;
		//transform.rotation.z;
		//Random.value;
		/*
		int facing = transform.rotation.z;
		double x = r.nextDouble ();
		double thresh = 0.0;
		*/
		if (s.playerWithinBounds ())
			return;
		//put boundaries check lol

		float px = player.transform.position.x;
		float py = player.transform.position.y;
		float x = transform.position.x;
		float y = transform.position.y;
		float dx = px - x;
		float dy = py - y;
		float diag = Mathf.Sqrt (dx * dx + dy * dy);

		rigidbody.velocity = new Vector2 (dx / diag * SPEED, dy / diag * SPEED);
	}
}
