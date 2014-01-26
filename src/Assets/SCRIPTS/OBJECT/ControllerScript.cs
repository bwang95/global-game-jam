using UnityEngine;
using System.Collections;

public enum Character {MIDAS, WIZARD, SHADOW};

public class ControllerScript : MonoBehaviour {


	//unlocked characters
	bool[] unlocked = new bool[3];
	Character currentChar = Character.MIDAS;

    public int speed = 20;
    private int facing = 1;
    private SpriteRenderer renderer;
    public Sprite[] sprites;

    void Start()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
        for (int k = 0; k < unlocked.Length; k++)
            unlocked[k] = true;
    }

    // Update is called once per frame
    void Update()
    {
        float x = 0, y = 0;
        if (Input.GetKey(KeyCode.A))
        {
            facing = 2;
            x -= 1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            x += 1;
            facing = 3;
        }

        if (Input.GetKey(KeyCode.W))
        {
            y += 1;
            facing = 0;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            y -= 1;
            facing = 1;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            attack();
        }

        if (Input.GetKey(KeyCode.Alpha1) && unlocked[0])
            currentChar = Character.MIDAS;
        else if (Input.GetKey(KeyCode.Alpha2) && unlocked[1])
            currentChar = Character.WIZARD;
        else if (Input.GetKey(KeyCode.Alpha3) && unlocked[2])
            currentChar = Character.SHADOW;
        
        int spriteSet = getCharIndex(currentChar) * 4;
        renderer.sprite = sprites[spriteSet + facing];

        rigidbody.velocity = new Vector2(x * speed, y * speed);
	}

	public Character getChar(){
		return currentChar;
	}

    int getCharIndex(Character c)
    {
        switch (c)
        {
            case Character.MIDAS: return 0;
            case Character.WIZARD: return 1;
            case Character.SHADOW: return 2;
        }
        return -1;
    }

    void attack()
    {
        switch (currentChar)
        {
            case Character.MIDAS :
                return;
            case Character.WIZARD :
                return;
            case Character.SHADOW :
                return;
        }
    }
}
