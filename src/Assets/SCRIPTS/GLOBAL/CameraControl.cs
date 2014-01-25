using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	private Vector3 endLoc;

	void Start () {
		setPosition(new Vector3(0,0,-5));
		endLoc = Camera.main.transform.position;
	}

	void Update () {
		if(Input.GetKeyDown("w")){
			endLoc.y += 1;
		}else if (Input.GetKeyDown("s")){
			endLoc.y -= 1;
		}
		if(Input.GetKeyDown("a")){
			endLoc.x -= 1;
		}else if (Input.GetKeyDown("d")){
			endLoc.x += 1;
		}

		if (!endLoc.Equals(Camera.main.transform.position)){
			cameraMove();
		}
	}

	void cameraMove(){
		Vector3 dist = distanceBetween(endLoc, Camera.main.transform.position);
		if(dist.magnitude <= .001){
			setPosition (endLoc);
		}else{
			Camera.main.transform.Translate(dist.x/2, dist.y/2, dist.z/2);
		}
	}

	Vector3 distanceBetween(Vector3 a, Vector3 b){
		Vector3 position = Camera.main.transform.position;
		return new Vector3(a.x-b.x, a.y - b.y, 0);
	}

	void setPosition(Vector3 a){
		Camera.main.transform.position = a;
	}
}
