using UnityEngine;
using System.Collections;

public class backgroundMusic : MonoBehaviour {

	/**
	 * Script for the background music so it continues to play when a new scene is loaded
	 * */
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
