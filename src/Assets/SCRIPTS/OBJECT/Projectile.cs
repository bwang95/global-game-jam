using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	private Vector3 velocity;

	// Use this for initialization
	void Start () {
		
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
				Destroy (this);
			}
		}
		transform.Translate (velocity);
	}
}
