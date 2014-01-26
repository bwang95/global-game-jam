using UnityEngine;
using System.Collections;

public class PROTAL : MonoBehaviour {

	ControllerScript player;
	public GameObject portal;
	bool isWinnable = false;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<ControllerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!isWinnable){
			for (int i = 0; i < player.unlocked.Length; i++){
				if(!player.unlocked[i]) return;
			}

			Instantiate(portal, transform.position, Quaternion.identity);
			isWinnable = true;
		}else{
			Collider[] collisions = Physics.OverlapSphere(transform.position, 5);
			for (int n = 0; n < collisions.Length; n++){
				if(collisions[n].gameObject.tag == "Player"){
					Application.LoadLevel(5);
				}
			}
		}
	}
}
