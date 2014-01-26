using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {

	public int type;
	private GameObject player;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (player.collider.bounds.Intersects(gameObject.collider.bounds)){
			player.GetComponent<ControllerScript>().setInv(type);
			Destroy(gameObject);
		}
	}

	public void setType(int type){
		this.type = type;
	}
}
