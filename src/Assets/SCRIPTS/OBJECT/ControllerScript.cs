using UnityEngine;
using System.Collections;

public enum Character {MIDAS, WIZARD, SHADOW};

public class ControllerScript : MonoBehaviour {


	//unlocked characters
	bool[] unlocked = new bool[3];
	Character currentChar = Character.MIDAS;

    public int speed = 20;
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
        int spriteSet = getCharIndex(currentChar) * 4;
        if (Input.GetKey(KeyCode.A))
        {
            x -= 1;
            renderer.sprite = sprites[spriteSet + 2];
        }
        else if (Input.GetKey(KeyCode.D))
        {
            x += 1;
            renderer.sprite = sprites[spriteSet + 3];
        }

        if (Input.GetKey(KeyCode.W))
        {
            y += 1;
            renderer.sprite = sprites[spriteSet];
        }
        else if (Input.GetKey(KeyCode.S))
        {
            y -= 1;
            renderer.sprite = sprites[spriteSet + 1];
        }

        if (Input.GetKey(KeyCode.Space))
        {
            attack();
        }

        if (Input.GetKey(KeyCode.Alpha1) && unlocked[0])
        {
            currentChar = Character.MIDAS;
            renderer.sprite = sprites[1];
        }
        else if (Input.GetKey(KeyCode.Alpha2) && unlocked[1])
        {
            currentChar = Character.WIZARD;
            renderer.sprite = sprites[5];
        }
        else if (Input.GetKey(KeyCode.Alpha3) && unlocked[2])
        {
            currentChar = Character.SHADOW;
            renderer.sprite = sprites[9];
        }

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
