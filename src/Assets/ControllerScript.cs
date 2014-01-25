using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

    int speed = 5;

	// Update is called once per frame
	void Update () {
        float x = 0, y = 0;
        if (Input.GetKey(KeyCode.A))
            x -= 1;
        else if (Input.GetKey(KeyCode.D))
            x += 1;

        if (Input.GetKey(KeyCode.W))
            y += 1;
        else if (Input.GetKey(KeyCode.S))
            y -= 1;

        rigidbody.velocity = new Vector3(x * speed, y * speed);
	}
}
