﻿using UnityEngine;
using System.Collections;

public class GenericEnemyBehavior : MonoBehaviour {

	private GameObject player;
	public float SPEED;
	private EnemyLimiter s;
	private Vector2 point;
    public Sprite[] sprites;
	private SpriteRenderer renderer;
	public GameObject projectile;

	private int character;
	private int facing; //0 = up, 1 = down, 2 = right, 3 = left
	private bool invisible;
	float cooldown;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		s = gameObject.GetComponent<EnemyLimiter>();
		SPEED = 5*Time.deltaTime;
        renderer = gameObject.GetComponent<SpriteRenderer>();
		character = 0;
		facing = 1;
		cooldown = Random.Range(3,4);
	}
	void Update () {
		character = (int)(player.GetComponent<ControllerScript> ()).getChar ();
		renderer.sprite = invisible ? null : sprites [character * 4 + facing];
		if (!s.playerWithinBounds ())
			return;

			float dx = player.transform.position.x - transform.position.x;
			float dy = player.transform.position.y - transform.position.y;
			float diag = Mathf.Sqrt (dx * dx + dy * dy);
			SPEED = 5 * Time.deltaTime;
			if (Mathf.Abs(dy / dx) >= 1)
			{
				if(dy > 0)
					facing = 0; //up
				else
					facing = 1; //down
			}
			else
			{
				if (dx > 0)
					facing = 2; //right
				else
					facing = 3; //left
			}
		
		switch ((player.GetComponent<ControllerScript>()).getChar()) {
				case Character.MIDAS:
						invisible = false;
						transform.Translate (dx / diag * SPEED, dy / diag * SPEED, 0);
						break;
				case Character.WIZARD:
					invisible = false;
					if(cooldown <= 0){
						GameObject clone = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
						clone.GetComponent<EnemyProjectile>().setVelocity(new Vector3(dx / diag * SPEED, dy / diag * SPEED, 0));
						cooldown = Random.Range(3f,4f);
					}
					cooldown -= Time.deltaTime;
					if(diag < 10){
						dx *= -1;
						dy *= -1;
					}
					transform.Translate (dx / diag * SPEED, dy / diag * SPEED, 0);
					break;
				case Character.SHADOW:
					if (diag < 7){
						invisible = true;
						break;
					} else {
						invisible = false;
					}
					if(point.x == 0 && point.y == 0)
						point = s.randPoint();
					else{
						dx = point.x - transform.position.x;
						dy = point.y - transform.position.y;
						diag = Mathf.Sqrt (dx * dx + dy * dy);
						if(diag < 0.5)
							point = s.randPoint();
					}
					if (Mathf.Abs(dy / dx) >= 1)
					{
						if(dy > 0)
							facing = 0; //up
						else
							facing = 1; //down
					}
					else
					{
						if (dx > 0)
							facing = 2; //right
						else
							facing = 3; //left
					}
					transform.Translate (dx / diag * SPEED, dy / diag * SPEED, 0);
					break;
			}
	}
}
