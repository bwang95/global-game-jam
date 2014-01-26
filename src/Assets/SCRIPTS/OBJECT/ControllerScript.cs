﻿using UnityEngine;
using System.Collections;

public enum Character {MIDAS, WIZARD, SHADOW};

public class ControllerScript : MonoBehaviour {


	//unlocked characters
	public bool[] unlocked = new bool[3];
	Character currentChar = Character.MIDAS;
	private int inv;

	public int lives;
    public int hitpoints = 1;
    private float invul = -1;
    private float invulDuration = -1;
    public int speed = 20;
    private int facing = 1;
    private SpriteRenderer renderer;
    public Sprite[] sprites;
	private Vector3[] abuseBallLoc = {new Vector3(0,4,0), new Vector3(0, -4, 0), new Vector3(-3,0,0), new Vector3(3,0,0)};

    void Start()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
        unlocked[0] = true;

		//
		gameObject.GetComponent<ParticleSystem> ().renderer.sortingLayerName = "Midas";
		//
		lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitpoints <= 0)
        {
			lives--;
            hitpoints = 1;
            reset();
        }
        float x = 0, y = 0;
        if (Time.time > invul + invulDuration)
            invul = -1;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack();
        }

        if (Input.GetKey(KeyCode.Alpha1) && unlocked[0])
            currentChar = Character.MIDAS;
        else if (Input.GetKey(KeyCode.Alpha2) && unlocked[1])
            currentChar = Character.WIZARD;
        else if (Input.GetKey(KeyCode.Alpha3) && unlocked[2])
            currentChar = Character.SHADOW;
        
        int spriteSet = getCharIndex(currentChar) * 5;
        renderer.sprite = sprites[spriteSet + facing];

		if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl) ||
            Input.GetKeyDown(KeyCode.RightCommand) || Input.GetKeyDown(KeyCode.LeftCommand) || Input.GetKeyDown (KeyCode.Q)){
			useInv();
		}

		setAbuseBallLoc(facing);

        rigidbody.velocity = new Vector2(x * speed, y * speed);
	}

	public void setInv(int item){
        if((item == 4 && inv == 5) || (item == 5 && inv == 4)){
            inv = 6;
            return;
        }else if(item == 1 || item == 2){
			unlocked[item] = true;
		}else{
			inv = item;
		}
	}

	public int getInv(){
		return inv;
	}

	private void useInv(){
		switch(inv){
		    case 0:
                print("Thou dost not have an object at thy disposal");
                break;
            case 3:
                hitpoints++;
				setInv(0);
                break;
            case 6:
                invul = Time.time;
                invul = 10;
				setInv(0);
                break;
            case 7:
                //Set speed and such
				setInv(0);
                break;
            case 8:
                setInv((int)(Random.value * 9));
				setInv(0);
                break;
            //case 9:
                
              //  break;

		//WRITE EFFECTS HERE.
		}
        

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
                Collider[] collisions = Physics.OverlapSphere(gameObject.GetComponent<SphereCollider>().center + transform.position, 
                    gameObject.GetComponent<SphereCollider>().radius);
                for(int i = 0; i < collisions.Length; i++){
                    print(collisions[i]);
                    if (collisions[i].gameObject.tag == "Enemy")
                    {
                        Destroy(collisions[i].gameObject);
                    }
                }
                return;
            case Character.WIZARD :
                return;
            case Character.SHADOW :
                return;
        }
    }

	void setAbuseBallLoc(int index){
		gameObject.GetComponent<SphereCollider>().center = abuseBallLoc[index];
	}

    void reset()
    {
        transform.position = new Vector3(0, 0);
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag.Equals("Enemy"))
        {
            hitpoints--;
            invul = Time.time;
            invulDuration = 1;
        }
    }
}
