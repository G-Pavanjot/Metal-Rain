using UnityEngine;
using System.Collections;

public class EdgeCollision : MonoBehaviour {
	/**
	 * Just a script checking if the enemy has left the outer barriers
	 * */
	void OnTriggerExit(Collider other){
		if (other.tag == "Enemy") {
			other.gameObject.GetComponent<BoxCollider>().enabled = true;
			other.gameObject.GetComponent<SphereCollider>().enabled = true;
			other.gameObject.GetComponent<CapsuleCollider>().enabled = false;
		}
	}
}
