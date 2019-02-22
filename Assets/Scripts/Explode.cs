using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

	/**
	 * Simple script which plays the explosion sound when the boss' nuke explodes, also uses the Unity Particle System to create the fire effect
	 * 
	 * */
	AudioSource expSound;
	
	// Use this for initialization
	void Awake () {
		expSound = GetComponent<AudioSource> ();
		var explodePart = GetComponent<ParticleSystem>();
		explodePart.Play();
		expSound.Play ();
		Destroy(gameObject, explodePart.duration);
	}

}
