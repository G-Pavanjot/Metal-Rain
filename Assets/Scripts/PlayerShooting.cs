using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {
	/**
	 * This class detects the direction the right joystick on a controller is pointed to, it then rotates the player to face that direction
	 * The player then begins shooting every 0.12 seconds
	 * */

	string horizontStick = "LookStick1";
	string vertStick = "LookStick2";
	public Rigidbody bullet;
	public float shootingSpeed = 0.12f;
	AudioSource shootSound;

	public GameObject bulletStart;

	float shootTimer;
	// Use this for initialization
	void Awake () {
		shootSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		shootTimer += Time.deltaTime;

		Vector3 direction = Vector3.right * Input.GetAxis (horizontStick) + Vector3.forward * Input.GetAxis (vertStick) * -1;
		if(direction.sqrMagnitude > 0.0f && shootTimer >= shootingSpeed)
		{
			transform.rotation = Quaternion.LookRotation(direction);
			shootTimer = 0f;
			shootSound.Play();
			Rigidbody instanproj = Instantiate(bullet, new Vector3(bulletStart.transform.position.x, bulletStart.transform.position.y, bulletStart.transform.position.z), transform.rotation) as Rigidbody;
			instanproj.velocity = transform.TransformDirection(new Vector3(0,0,10f));
			Destroy (instanproj.gameObject, 1.0f);
		}
			  
	}

}
