using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour {

	private Transform planet;
	public GameObject effect;
	private Animator anim;
	public Sprite[] heads;
	private SpriteRenderer rend;

	private float speed;
	public float minSpeed;
	public float maxSpeed;




	void Start(){	

		int randHead = Random.Range(0, heads.Length);
		rend = GetComponent<SpriteRenderer>();
		rend.sprite = heads[randHead];

		anim = GetComponent<Animator>();
		anim.SetBool("Running", true);
		speed = Random.Range(minSpeed, maxSpeed);
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
			this.gameObject.transform.parent = planet.transform;
		}
	}

	public void Death(){

		Instantiate(effect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

}
