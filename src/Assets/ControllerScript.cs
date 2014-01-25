using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

    int speed = 5;
    bool colliding = false;

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

        if (!colliding)
            rigidbody.velocity = new Vector2(x * speed, y * speed);
        else rigidbody.velocity = Vector2.zero;
	}

    /*void OnCollisionEnter(Collision c)
    {
        print("Collides!");
        rigidbody.velocity = Vector2.zero;
        colliding = true;
    }

    void OnCollisionExit(Collision c)
    {
        colliding = false;
    }*/
}
