using UnityEngine;
using System.Collections;

public class GenericEnemyBehavior : MonoBehaviour {

	public GameObject player;
	private float SPEED;
	public EnemyLimiter s;
    public Sprite up, down, left, right;
	
	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		s = (EnemyLimiter) gameObject.GetComponent(typeof(EnemyLimiter));
		SPEED = 5*Time.deltaTime;
	}
	void Update () {
		if (!s.playerWithinBounds ())
			return;
		/*
		switch(playerChar){
		case MIDAS:
		*/
			float dx = player.transform.position.x - transform.position.x;
			float dy = player.transform.position.y - transform.position.y;

            if (Mathf.Abs(dy / dx) >= 1)
            {
                if(dy > 0)
                   gameObject.GetComponent<SpriteRenderer>().sprite = up;
                else
                   gameObject.GetComponent<SpriteRenderer>().sprite = down;
            }
            else
            {
                if (dx > 0)
                    gameObject.GetComponent<SpriteRenderer>().sprite = right;
                else
                    gameObject.GetComponent<SpriteRenderer>().sprite = left;
            }

			float diag = Mathf.Sqrt (dx * dx + dy * dy);
			SPEED = 5*Time.deltaTime;
            
            

			transform.Translate(dx / diag * SPEED, dy / diag * SPEED,0);
		/*
			break;
		case WIZARD:
			//
		*/
	}
}
