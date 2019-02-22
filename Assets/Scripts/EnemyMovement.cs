using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	/**
	 * This script allows the enemy to travel across the map towards the player
	 * */
	Transform player;
	UnityEngine.AI.NavMeshAgent nav;

	PlayerHealth playerHealth;

	Animator enemyAnim;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Soldier").transform;
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
		enemyAnim = GetComponent <Animator> ();
		playerHealth = player.GetComponent <PlayerHealth> ();
	}
	
	
	void Update ()
	{
		if (playerHealth.Health > 0) {	
			nav.SetDestination (player.position);
		} else {
			enemyAnim.SetTrigger("PlayerDead");
			nav.enabled = false;

		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Soldier")
			enemyAnim.SetBool ("Attack", true);
	}
	void OnTriggerExit()
	{
		enemyAnim.SetBool ("Attack", false);
	}
}
