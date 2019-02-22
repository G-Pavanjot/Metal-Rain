using UnityEngine;
using System.Collections;

public class BossHealth : MonoBehaviour {
	/**
	 * The script which contains the boss' health
	 * The boss has 200 health and each bullet does 5 damage
	 * */

	public float enemyHealth = 200f;
	public float bulletDamage = 5f;
	public GameObject difficulty;
	public GameObject score;
	public int killScore = 50;
	
	bool enemyDied = false;
	//Animator enemyAnim;
	
	void Awake(){
		//enemyAnim = GetComponent<Animator> ();
		score = GameObject.FindGameObjectWithTag ("Score");
		difficulty = GameObject.FindGameObjectWithTag ("Diff");
	}
	
	void OnTriggerEnter(Collider other){
		if (!(enemyDied)) {
			if (other.tag == "Bullet") {
				enemyHealth -= bulletDamage;
				Destroy (other.gameObject);
			}
			if (enemyHealth <= 0) {
				//gameObject.GetComponent<SphereCollider> ().enabled = false;
				score.GetComponent<ScoreScript> ().deadInc (killScore);
				dead ();
			}
		} else {
			if (other.tag == "Bullet") {
				Destroy (other.gameObject);
			}
		}
	}
	
	void dead(){
		//difficulty.GetComponent<spawnTimeUp> ().crawlCount--;
		
		enemyDied = true;
		//enemyAnim.SetTrigger ("Dead");
		Destroy (gameObject, 1f);
	}
}
