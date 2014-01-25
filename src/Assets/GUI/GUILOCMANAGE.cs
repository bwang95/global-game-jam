using UnityEngine;
using System.Collections;

public class GUILOCMANAGE : MonoBehaviour {

	public Texture image;
	private int size = 30; 

	void OnGUI(){
		GUI.Box (new Rect (Screen.width/2 - size/2,Screen.height/2 - size/2 ,30,30), image);
	}
}
