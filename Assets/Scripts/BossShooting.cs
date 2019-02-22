using UnityEngine;
using System.Collections;

public class BossShooting : MonoBehaviour {
	/**
	 * Script to allow the boss to shoot its nuke/bullets at the player
	 * */
	public GameObject bullet;
	public float shootingSpeed = 0.12f;
	Transform player;
	PlayerHealth playerHealth;
	float shootTimer;
	AudioSource shootSound;
	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Soldier").transform;
		playerHealth = player.GetComponent <PlayerHealth> ();
		shootSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		shootTimer += Time.deltaTime;
		if (playerHealth.Health > 0) {
			if (shootTimer >= shootingSpeed) {
				shootTimer = 0f;
				shootSound.Play();
				GameObject instanproj = Instantiate (bullet, new Vector3 (transform.position.x, transform.position.y, transform.position.z), transform.rotation) as GameObject;
				//instanproj.velocity = transform.TransformDirection(new Vector3(0,0,10f));
				Destroy (instanproj, 3f);

			}
		}
		
	}


}
