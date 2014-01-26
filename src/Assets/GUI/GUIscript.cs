using UnityEngine;
using System.Collections;

public class GUIscript : MonoBehaviour {
	
	//public Texture image;
	public ControllerScript player;
	public ItemController items;
	public Texture[] itemTextures;
	//private int size = 30; 

	void Start(){
	}

	void Update(){
		if (player == null) {
			player = GameObject.FindGameObjectWithTag ("Player").GetComponent<ControllerScript>();
		}
		if (items == null) {
			items = gameObject.GetComponent<ItemController> ();
		}

	}

	void OnGUI(){
		//GUI.Box (new Rect (Screen.width/2 - size/2,Screen.height/2 - size/2 ,30,30), image);
		GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.1f - 20, 100, 100), "lives: " + player.lives.ToString());

		GUI.Box (new Rect (Screen.width * 0.1f, Screen.height * 0.1f, 50, 50), itemTextures[player.getInv()]);
	}
}
