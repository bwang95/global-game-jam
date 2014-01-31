using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	private Vector3 velocity;
	ControllerScript player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<ControllerScript>();
		print(player.facing);
		setVelocity(player.projectileDir[player.facing]);
	}

	public void setVelocity(Vector3 vect){
		velocity = vect * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		Collider[] collisions = Physics.OverlapSphere(transform.position, 1);
		for(int i = 0; i < collisions.Length; i++){
			if (collisions[i].gameObject.tag == "Enemy")
			{
				Destroy(collisions[i].gameObject);
				Destroy (gameObject);
			}else if (collisions[i].tag == "Untagged"){
				Destroy (gameObject);
			}
			print(collisions[i].gameObject.tag);
		}
		transform.Translate (velocity);
	}
}
