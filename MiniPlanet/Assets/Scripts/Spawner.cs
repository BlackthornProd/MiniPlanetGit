using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public Transform[] poses;
	public GameObject slime;

	private float timeBtwSpawns;
	public float startTimeBtwSpawns;

	void Start(){

		timeBtwSpawns = startTimeBtwSpawns;
	}

	void Update(){

		if(timeBtwSpawns <= 0){
			int rand = Random.Range(0, poses.Length);
			Instantiate(slime, poses[rand].position, Quaternion.identity);
			timeBtwSpawns = startTimeBtwSpawns;
		} else {
			timeBtwSpawns -= Time.deltaTime;
		}
	}
}
