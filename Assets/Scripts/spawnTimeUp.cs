using UnityEngine;
using System.Collections;

public class spawnTimeUp : MonoBehaviour {

	/**
	 * This script controls the rate at which enemies are spawning
	 * There should be a delay between each enemy spawning, however as the game progresses this delay should shorten
	 * */

	public GameObject spawner;
	public GameObject enemy;
	public GameObject boss;
	public Transform bossSpawn;

	public float surviveTime = 2f;
	private float spawnTime = 2.4f;
	public bool bossLevel = false;
	public int crawlCount = 0;
	public int crawlLimit = 0;
	private int counter = 0;
	private float difficultyTimeSpan;
	private float spawn;

	// Update is called once per frame
	void Update () {
		difficultyTimeSpan += Time.deltaTime;
		spawn += Time.deltaTime;
		if (spawn >= spawnTime) {
			spawn = 0f;
			if(crawlCount < crawlLimit){
			crawlCount++;
				//print (crawlCount);
			spawner.GetComponent<CrawlerSpawner>().SpawningFunction();
			}
			if(crawlCount >= crawlLimit && bossLevel){
				Instantiate(boss,bossSpawn.position, bossSpawn.rotation);
				bossLevel = false;
			}
		}
		if (difficultyTimeSpan >= surviveTime) {
			difficultyTimeSpan = 0f;
			if(spawnTime >= 0.4){
				spawnTime -= 0.1f;
		}if(spawnTime%1 == 0){
				enemy.GetComponent<EnemyHealth>().enemyHealth += 5f;
			}
	}
}
}