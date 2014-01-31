using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	private Vector3 endLoc;
	public GameObject player = null;
	private const int speedInv = 25;

	void Start () {
		setPosition(new Vector3(0,0,-5));
		endLoc = Camera.main.transform.position;
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update () {

		if(player == null){
			player = GameObject.FindGameObjectWithTag("Player");
		}

		endLoc = findClosestRoom();

		if (!endLoc.Equals(Camera.main.transform.position)){
			cameraMove();
		}
	}

	void cameraMove(){
		Vector3 dist = distanceBetween(endLoc, Camera.main.transform.position);
		if(dist.magnitude <= .001){
			setPosition (endLoc);
		}else{
			Camera.main.transform.Translate(dist.x/speedInv, dist.y/speedInv, dist.z/speedInv);
		}
	}

	Vector3 distanceBetween(Vector3 a, Vector3 b){
		return new Vector3(a.x-b.x, a.y - b.y, 0);
	}

	void setPosition(Vector3 a){
		Camera.main.transform.position = a;
	}

	Vector3 findClosestRoom(){
		Vector3 playPos = player.transform.position;
		playPos.x = Mathf.Floor ((playPos.x + 15) / 30) * 30;
		playPos.y = Mathf.Floor ((playPos.y + 15) / 30) * 30;
		playPos.z = -5; 
		return playPos;
	}
}
