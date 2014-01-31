using UnityEngine;
using System.Collections;

public class ShadowFlames : MonoBehaviour {

	float time;

	// Use this for initialization
	void Start () {
		time = 0.25f;
	}
	
	// Update is called once per frame
	void Update () {
		if (time <= 0)
			Destroy (gameObject);
		time -= Time.deltaTime;
	}
}
