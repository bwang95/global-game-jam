using UnityEngine;
using System.Collections;

public class GenericEnemyBehavior : MonoBehaviour {

	private GameObject player;
	public float SPEED;
	private EnemyLimiter s;
    public Sprite up, down, left, right;
	private SpriteRenderer renderer;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		s = gameObject.GetComponent<EnemyLimiter>();
		SPEED = 5*Time.deltaTime;
        renderer = gameObject.GetComponent<SpriteRenderer>();
	}
	void Update () {
		if (!s.playerWithinBounds ())
			return;

			float dx = player.transform.position.x - transform.position.x;
			float dy = player.transform.position.y - transform.position.y;

            

			float diag = Mathf.Sqrt (dx * dx + dy * dy);
			SPEED = 5 * Time.deltaTime;

			switch ((player.GetComponent<ControllerScript>()).getChar()) {
				case Character.MIDAS:
						if (Mathf.Abs(dy / dx) >= 1)
						{
							if(dy > 0)
								renderer.sprite = up;
							else
								renderer.sprite = down;
						}
						else
						{
							if (dx > 0)
								renderer.sprite = right;
							else
								renderer.sprite = left;
						}

						transform.Translate (dx / diag * SPEED, dy / diag * SPEED, 0);
		
						break;
				case Character.WIZARD:

						break;
				case Character.SHADOW:

						break;
		}
	}
}
