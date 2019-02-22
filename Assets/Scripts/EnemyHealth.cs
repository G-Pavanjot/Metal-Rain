using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	/**
	 * Script containing the health of the enemy this script is assigned to
	 * */

	public float enemyHealth = 10f;
	public float bulletDamage = 5f;
	public GameObject difficulty;
	public GameObject score;
	public int killScore = 1;

	bool enemyDied = false;
	Animator enemyAnim;

	void Awake(){
		enemyAnim = GetComponent<Animator> ();
	}

	void OnTriggerEnter(Collider other){
		if (!(enemyDied)) {
			if (other.tag == "Bullet") {
				enemyHealth -= bulletDamage;
				Destroy (other.gameObject);
			}
			if (enemyHealth <= 0) {
				gameObject.GetComponent<SphereCollider> ().enabled = false;
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
		enemyAnim.SetTrigger ("Dead");
		Destroy (gameObject, 1f);
	}
}
