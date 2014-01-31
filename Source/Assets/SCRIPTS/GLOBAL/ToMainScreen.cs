using UnityEngine;
using System.Collections;

public class ToMainScreen : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("q")){
			Application.LoadLevel(0);
		}
	}
}
