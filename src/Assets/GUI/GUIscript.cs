using UnityEngine;
using System.Collections;

public class GUIscript : MonoBehaviour {
	
	public ControllerScript player;
	public Texture[] itemTextures;
	public Texture[] cardTextures;

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
		GUI.Box (new Rect (Screen.width * 0.05f, Screen.height * 0.05f, 75, 75), itemTextures[player.getInv()]);
		//Cards
		GUI.Box (new Rect (Screen.width * 0.05f, Screen.height - 100, 75, 75), player.unlocked[0] ? cardTextures[0] : null);
		GUI.Box (new Rect (Screen.width * 0.05f + 80, Screen.height - 100, 75, 75), player.unlocked[1] ? cardTextures[1] : null);
		GUI.Box (new Rect (Screen.width * 0.05f + 160, Screen.height - 100, 75, 75), player.unlocked[2] ? cardTextures[2] : null);
		GUI.Label (new Rect (Screen.width * 0.05f, Screen.height - 120, 100, 100), "1");
		GUI.Label (new Rect (Screen.width * 0.05f + 80, Screen.height - 120, 100, 100), "2");
		GUI.Label (new Rect (Screen.width * 0.05f + 160, Screen.height - 120, 100, 100), "3");
	}
}
