using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {
	/**
	 * The script for the level select
	 * Starts the background music and loads the selected level
	 * */
	public GameObject backMusic;

	public void Level1()
	{
		Application.LoadLevel ("Level 00");
	}

	public void Level2()
	{
		Application.LoadLevel ("Level01");
		backMusic.SetActive (true);
	}

	public void Level3()
	{
		Application.LoadLevel ("BossLevel");
		backMusic.SetActive (true);
	}

}
