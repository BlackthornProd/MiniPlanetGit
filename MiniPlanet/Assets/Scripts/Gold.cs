using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour {

	public GameObject effect;
	private Transform planet;

	private float speed;
	public float minSpeed;
	public float maxSpeed;

	void Start(){

		planet = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

		speed = Random.Range(minSpeed, maxSpeed);
	}

	void Update(){
		transform.position = Vector2.MoveTowards(transform.position, planet.position, speed * Time.deltaTime);
	}


	void OnTriggerEnter2D(Collider2D other){

		if(other.CompareTag("Slime")){
			other.GetComponent<Slime>().Death();
		}

		Instantiate(effect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
