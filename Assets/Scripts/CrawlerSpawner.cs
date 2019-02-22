using UnityEngine;
using System.Collections;

public class CrawlerSpawner : MonoBehaviour {

	/**
	 * Simple script which randomly selects one of the many spawn points on the map to spawn a crawler enemy
	 * */

	public GameObject player;
	public GameObject crawler;
	public Transform[] spawnPoints;
	public float spawnSpeed = 2.5f;

	
	public void SpawningFunction(){

		if(!(player.GetComponent<PlayerHealth>().dead)){
		int spawnArrayIndex = Random.Range (0, spawnPoints.Length);

		Instantiate (crawler, spawnPoints[spawnArrayIndex].position, spawnPoints[spawnArrayIndex].rotation);
		crawler.gameObject.GetComponent<BoxCollider>().enabled = false;
		crawler.gameObject.GetComponent<SphereCollider>().enabled = false;
		}

	}
	
}
