using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {

	public int type;
	private GameObject player;
	private SpriteRenderer renderer;
	public Sprite[] sprites;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		renderer = gameObject.GetComponent<SpriteRenderer>();
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
		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[type];
	}
}
