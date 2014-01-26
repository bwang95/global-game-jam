using UnityEngine;
using System.Collections;

public enum Character {MIDAS, WIZARD, SHADOW};

public class ControllerScript : MonoBehaviour {


	//unlocked characters
	bool[] unlocked = new bool[3];
	Character currentChar = Character.MIDAS;

    public int speed = 20;

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

		if (Input.GetKey (KeyCode.Alpha1))
			currentChar = Character.MIDAS;
		else if (Input.GetKey (KeyCode.Alpha2))
			currentChar = Character.WIZARD;
		else if (Input.GetKey (KeyCode.Alpha3))
			currentChar = Character.SHADOW;

        rigidbody.velocity = new Vector2(x * speed, y * speed);
	}

	public Character getChar(){
		return currentChar;
	}
}
