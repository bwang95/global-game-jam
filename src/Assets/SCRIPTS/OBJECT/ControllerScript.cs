using UnityEngine;
using System.Collections;

public enum Character {MIDAS, WIZARD, SHADOW};

public class ControllerScript : MonoBehaviour {


	//unlocked characters
	bool[] unlocked = new bool[3];
	Character currentChar = Character.MIDAS;
	private int inv;

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

		if (Input.GetKeyDown (KeyCode.Alpha1))
			currentChar = Character.MIDAS;
		else if (Input.GetKeyDown (KeyCode.Alpha2))
			currentChar = Character.WIZARD;
		else if (Input.GetKeyDown (KeyCode.Alpha3))
			currentChar = Character.SHADOW;

		if (Input.GetKeyDown(KeyCode.RightControl)){
			useInv();
		}

        rigidbody.velocity = new Vector2(x * speed, y * speed);
	}

	public void setInv(int item){
		inv = item;
	}

	private void useInv(){
		switch(inv){
		case 0:
			break;
		//WRITE EFFECTS HERE.
		}
	}

	public Character getChar(){
		return currentChar;
	}
}
