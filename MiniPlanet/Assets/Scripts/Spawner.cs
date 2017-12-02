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

		Debug.Log(startTimeBtwSpawns);

		if(timeBtwSpawns <= 0){
			int rand = Random.Range(0, poses.Length);
			int randSlime = Random.Range(0, slimes.Length);
			Instantiate(slimes[randSlime], poses[rand].position, Quaternion.identity);
			timeBtwSpawns = startTimeBtwSpawns;
		} else {
			timeBtwSpawns -= Time.deltaTime;
		}
	}
}
