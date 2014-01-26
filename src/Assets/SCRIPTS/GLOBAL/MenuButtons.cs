using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour 
{
	string options;
	int width;
	int height;
	int w;
	int h;

	void Start()
	{
		options= "Options";
		width = 100;
		height = 50;
		w=100;
		h=50;
	}



	void OnGUI()
	{

		if (GUI.Button(new Rect((Screen.width * .5f)-(width*.5f), (Screen.height * .65f)-(height*.5f),width,height),"PLAY!"))
		{
			Application.LoadLevel(1);
		}

		if (GUI.Button(new Rect((Screen.width * .5f)-(w*.5f), (Screen.height * .80f)-(h*.5f),w,h), options))
		{
			options = "There are NO Options!";
			w=200;
		}

	}

}
