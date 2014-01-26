using UnityEngine;
using System.Collections;

public class GUIscript : MonoBehaviour {
	
	public ControllerScript player;
	public Texture[] itemTextures;

	void Start(){
	}

	void Update(){
		if (player == null) {
			player = GameObject.FindGameObjectWithTag ("Player").GetComponent<ControllerScript>();
		}
	}

	void OnGUI(){
		//lives
		GUI.Label (new Rect (Screen.width * 0.05f, Screen.height * 0.05f - 20, 100, 100), "lives: " + player.lives.ToString());
		//Item
		GUI.Box (new Rect (Screen.width * 0.05f, Screen.height * 0.05f, 56, 56), itemTextures[player.getInv()]);
		//
	}
}
