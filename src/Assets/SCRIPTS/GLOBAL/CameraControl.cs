using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	private Vector3 endLoc;
	public GameObject player;

	void Start () {
		setPosition(new Vector3(0,0,-5));
		endLoc = Camera.main.transform.position;
	}

	void Update () {

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
			Camera.main.transform.Translate(dist.x/4, dist.y/4, dist.z/4);
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
