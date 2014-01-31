using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {

	private Vector3 velocity;
	ControllerScript player;
	GenericEnemyBehavior enemy;
	float time;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<ControllerScript>();
		time = 3.0f;
	}

	public void setVelocity(Vector3 vect){
		velocity = vect;
	}
	
	// Update is called once per frame
	void Update () {
		if (time <= 0)
			Destroy (gameObject);
		time -= Time.deltaTime;
		Collider[] collisions = Physics.OverlapSphere(transform.position, 1);
		for(int i = 0; i < collisions.Length; i++){
			if (collisions[i].gameObject.tag == "Player")
			{
				player.hitpoints--;
				Destroy (gameObject);
			}else if (collisions[i].tag == "Untagged"){
				Destroy (gameObject);
			}
			print(collisions[i].gameObject.tag);
		}
		transform.Translate (velocity);
	}
}
