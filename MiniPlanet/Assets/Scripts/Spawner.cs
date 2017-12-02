using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public Transform[] poses;
	public GameObject[] slimes;

	private float timeBtwSpawns;
	public float startTimeBtwSpawns;
	public float decrement;

	void Start(){

		timeBtwSpawns = startTimeBtwSpawns;
	}

	void Update(){

		if(timeBtwSpawns <= 0){
			int rand = Random.Range(0, poses.Length);
			int randSlime = Random.Range(0, slimes.Length);
			Instantiate(slimes[randSlime], poses[rand].position, Quaternion.identity);
			if(startTimeBtwSpawns > 0.75f){
				startTimeBtwSpawns = startTimeBtwSpawns - decrement;
			}
			timeBtwSpawns = startTimeBtwSpawns;
		} else {
			timeBtwSpawns -= Time.deltaTime;
		}
	}
}
