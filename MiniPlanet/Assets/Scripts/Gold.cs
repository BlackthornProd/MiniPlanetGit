using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour {

	public GameObject effect;
	private Transform planet;
	private Shake shake;
	private Spawner spawner;

	private float speed;
	public float minSpeed;
	public float maxSpeed;

	private Planet player;

	public float cantDieTime = 0.5f;

	void Start(){

		spawner = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<Spawner>();

		shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Shake>();
		planet = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Planet>();

		speed = Random.Range(minSpeed, maxSpeed);
	}

	void Update(){
		transform.position = Vector2.MoveTowards(transform.position, planet.position, speed * Time.deltaTime);

		if(spawner.stop == true){
			speed = 0;
		}

		if(cantDieTime > 0){
			cantDieTime -= Time.deltaTime;
		} 
	}


	void OnTriggerEnter2D(Collider2D other){

		if(other.CompareTag("Slime") && spawner.stop == false){
			other.GetComponent<Slime>().Death();
			Death();
		}
		if(cantDieTime <= 0){
			player.GoldExplode();
			speed = 0;
			this.gameObject.transform.parent = other.transform;
		}
	
	}

	public void Death(){
			
			spawner.startTimeBtwSpawns = spawner.startTimeBtwSpawns + spawner.decrement;
			shake.Shaker(0.125f, 0.125f);
			Instantiate(effect, transform.position, Quaternion.identity);
			Destroy(gameObject);
	}
}
