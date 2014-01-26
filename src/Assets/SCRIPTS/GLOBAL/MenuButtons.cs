using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour 
{
	void OnGUI()
	{
		int width = 100;
		int height = 50;
		if (GUI.Button(new Rect((Screen.width * .5f)-(width*.5f), (Screen.height * .65f)-(height*.5f),width,height),"PLAY!"))
		{
			Application.LoadLevel(1);
		}
	}

}
