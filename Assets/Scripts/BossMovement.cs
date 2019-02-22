using UnityEngine;
using System.Collections;

public class BossMovement : MonoBehaviour {
	/**
	 * Script to move the boss towards the player using the nav mesh
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
}
