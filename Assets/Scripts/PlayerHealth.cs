using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	/**
	 * Script storing the player's current health and updates the UI slider to show the current health
	 * */

	public float Health = 100f;
	public float crawlerDamage = 20f;
	public float bossDamage = 30f;
	public GameObject explosion;

	public Slider healthBar;

	Animator animator;
	public bool dead = false;
	bool takingDamage = false;
	PlayerMovement playerMoving;
	PlayerShooting playerShoots;
	public float deadWait = 2.0f;

	float deadTimer = 0;

	void Awake () {
	
		animator = GetComponent <Animator> ();
		playerMoving = GetComponent <PlayerMovement> ();
		playerShoots = GetComponent <PlayerShooting> ();
	}

	void Update(){
		if (dead) {
			deadTimer += Time.deltaTime;
			if (deadTimer >= deadWait) {
				Application.LoadLevel ("Game Over");
			}
		}
	}

	void OnTriggerStay(Collider other){
		if (dead == false) {
			if(other.tag == "Enemy"){
				Health -= (crawlerDamage * Time.deltaTime);
				healthBar.value = Health;
				if (Health <= 0) {
					Health = 0;
					Died ();
				}
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (!dead) {
			if (other.tag == "BossBullet") {
				Health -= bossDamage;
				healthBar.value = Health;
				Destroy (other.gameObject);
				Instantiate (explosion, transform.position, transform.rotation);

				if (Health <= 0) {
					Health = 0;
					Died ();
				}
			} else if (other.tag == "Health") {
				if (Health < 100) {
					Destroy (other.gameObject);
				}
				Health += 50;

				if (Health >= 100) {
					Health = 100;

				}
				healthBar.value = Health;
			}
		}
	}

	/*void OnTriggerExit(Collider other){
		if (other.tag == "Enemy") {
			takingDamage = false;
		}
	}*/

	void Died(){
		animator.SetTrigger ("Die");

		dead = true;
		playerMoving.enabled = false;
		playerShoots.enabled = false;


	}

	/*void OnGUI(){
		GUI.Label (new Rect (10, 10, 150, 150), "Health: " + Health.ToString ("00"));
	}
*/
}
