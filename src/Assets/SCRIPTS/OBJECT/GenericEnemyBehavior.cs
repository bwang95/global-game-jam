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
	public EnemyLimiter s;
	
	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		s = (EnemyLimiter) gameObject.GetComponent(typeof(EnemyLimiter));

	}
	void Update () {
		if (!s.playerWithinBounds ())
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
