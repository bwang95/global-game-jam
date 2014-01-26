using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	private Vector3 velocity;

	// Use this for initialization
	void Start () {
		
	}

	void setVelocity(Vector3 vect){
		velocity = vect * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		collisions = Physics.OverlapSphere(transform.position, 5);
		for(int i = 0; i < collisions.Length; i++){
			print(collisions[i]);
			if (collisions[i].gameObject.tag == "Enemy")
			{
				Destroy(collisions[i].gameObject);
				Destroy (this);
			}
		}
		transform.Translate (velocity);
	}
}
