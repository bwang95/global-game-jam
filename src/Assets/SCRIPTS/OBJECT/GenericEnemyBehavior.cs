using UnityEngine;
using System.Collections;

public class GenericEnemyBehavior : MonoBehaviour {

	public GameObject player;
	private float SPEED;
	public EnemyLimiter s;
	
	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		s = (EnemyLimiter) gameObject.GetComponent(typeof(EnemyLimiter));
		SPEED = 5*Time.deltaTime;
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
			SPEED = 5*Time.deltaTime;

			transform.Translate(dx / diag * SPEED, dy / diag * SPEED,0);
	}
}
