using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour {

	private Transform planet;
	public GameObject effect;

	public float speed;

	void Start(){
		planet = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}


	void Update(){

		transform.position = Vector2.MoveTowards(transform.position, planet.position, speed * Time.deltaTime);
	}


	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			speed = 0;
			this.gameObject.transform.parent = other.transform;
		} else if(other.CompareTag("Slime")){
			speed = 0;
			this.gameObject.transform.parent = other.transform;
		}
	}

	public void Death(){

		Instantiate(effect, transform.position, Quaternion.identity);
	}

}
