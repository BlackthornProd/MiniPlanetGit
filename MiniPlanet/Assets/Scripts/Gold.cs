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



	void Start(){

		spawner = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<Spawner>();

		shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Shake>();
		planet = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

		speed = Random.Range(minSpeed, maxSpeed);
	}

	void Update(){
		transform.position = Vector2.MoveTowards(transform.position, planet.position, speed * Time.deltaTime);

		if(spawner.stop == true){
			speed = 0;
		}
	}


	void OnTriggerEnter2D(Collider2D other){

		if(other.CompareTag("Slime") && spawner.stop == false){
			other.GetComponent<Slime>().Death();
			spawner.startTimeBtwSpawns = spawner.startTimeBtwSpawns + spawner.decrement;
		}

		shake.Shaker(0.125f, 0.125f);
		Instantiate(effect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
