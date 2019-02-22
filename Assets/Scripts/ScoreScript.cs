using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	/**
	 * Script which displays the current score of the player
	 * When all the enemies in the current level have been killed, this script loads the next scene
	 * */

	static int deadCount = 0;
	public int level;
	public int numberEnemies;
	public string nextLevel;

	string gameOverWin = " ";
	public Text levelWin;

	void Awake()
	{
		switch (level) {
		case 0: 
			deadCount = 0;
			break;
		case 1:
			deadCount = 50;
			break;
		case 2:
			deadCount = 110;
			break;
		}
	}


	// Update is called once per frame
	void Update () {
		if (deadCount >= numberEnemies) {
			print ("Level won!");
			toNextLevel();
		}
	}

	private void  toNextLevel(){
		if (nextLevel != "x") {
			levelWin.gameObject.SetActive (true);
			gameOverWin = "Level Won!";
		}
		StartCoroutine("WaittoLoad");
		
	}
	
	IEnumerator WaittoLoad()
	{
		yield return new WaitForSeconds(5);

		Application.LoadLevel(nextLevel);
	}


	public void deadInc(int amount){
		deadCount += amount;
	}

	void OnGUI(){
		GUI.Label (new Rect (10, 25, 150, 150), "Score: " + deadCount.ToString ());
	}
}
