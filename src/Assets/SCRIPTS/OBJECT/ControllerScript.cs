using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

    public int speed = 20;
    private SpriteRenderer renderer;
    public Sprite up, down, left, right;

    void Start()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

	// Update is called once per frame
	void Update () {
        float x = 0, y = 0;
        if (Input.GetKey(KeyCode.A))
        {
            x -= 1;
            renderer.sprite = left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            x += 1;
            renderer.sprite = right;
        }

        if (Input.GetKey(KeyCode.W))
        {
            y += 1;
            renderer.sprite = up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            y -= 1;
            renderer.sprite = down;
        }

        rigidbody.velocity = new Vector2(x * speed, y * speed);
	}
}
