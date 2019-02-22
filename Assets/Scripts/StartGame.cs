using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	
	public void startingGame()
	{
		Application.LoadLevel ("Level 00");
	}
		
	public void levelSelect()
	{
		Application.LoadLevel ("Level Select");
	}

}
