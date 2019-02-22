using UnityEngine;
using System.Collections;

public class bossBulletMovement : MonoBehaviour {
	/**
	 * Script for using the nav mesh to navigate the boss' nuke bullets towards the player
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
		Invoke ("Explode", 3.0f);
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
/*	void OnTriggerEnter(Collider other){
			if (other.tag == "Bullet") {
			nav.enabled = false;
				Destroy (other.gameObject);
			Explode();
				//Destroy(gameObject);
			}
		}*/
	public void Explode(){
		nav.enabled = false;
		ParticleSystem explosion = GetComponent<ParticleSystem> ();
		explosion.Play ();
		Destroy (gameObject, explosion.duration);
	}
}

