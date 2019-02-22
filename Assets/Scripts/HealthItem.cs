using UnityEngine;
using System.Collections;

public class HealthItem : MonoBehaviour {

	/**
	 * Just the bulletColorChange code but used for the health item, turning it green
	 * */
		Renderer bulletRend;
		
		void Awake(){
			bulletRend = GetComponent <Renderer> ();
			bulletRend.material.color = Color.green;
		}
		void Update()
		{
			bulletRend.material.color = Color.green;
			
		}
	}

