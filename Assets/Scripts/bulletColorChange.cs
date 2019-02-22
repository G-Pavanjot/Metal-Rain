using UnityEngine;
using System.Collections;

public class bulletColorChange : MonoBehaviour {

	Renderer bulletRend;
 /*
 *
 * This code is used to change the bullets to appear black rather than the typical grey thats assigned by default to unity objects
 */
	void Awake(){
		bulletRend = GetComponent <Renderer> ();
		bulletRend.material.color = Color.black;
	}
	void Update()
	{
		bulletRend.material.color = Color.black;

	}
}
