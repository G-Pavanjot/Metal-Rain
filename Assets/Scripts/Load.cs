using UnityEngine;
using System.Collections;

public class Load : MonoBehaviour {

	// Use this for initialization
	public void GotoMenu () {
		Application.LoadLevel("Main Menu");
	
	}

	public void playAgain(){
		Application.LoadLevel ("Level 00");
	}

}
