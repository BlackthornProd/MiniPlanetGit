using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour {

	private Transform planet;
	public GameObject effect;
	private Animator anim;
	public Sprite[] heads;
	private SpriteRenderer rend;
	private LineRenderer lineRend;
	private Spawner spawner;

	private float speed;
	public float minSpeed;
	public float maxSpeed;

	private bool hasDamaged;
	private AudioSource source;
	public AudioClip squish;


	private Planet player;
	bool playedSound;

	public float cantDieTime = .5f;

	void Start(){	
		source = GetComponent<AudioSource>();
		spawner = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<Spawner>();

		int randHead = Random.Range(0, heads.Length);
		rend = GetComponent<SpriteRenderer>();
		rend.sprite = heads[randHead];

		anim = GetComponent<Animator>();
		anim.SetBool("Running", true);
		speed = Random.Range(minSpeed, maxSpeed);
		planet = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Planet>();

		lineRend = GetComponent<LineRenderer>();
		lineRend.enabled = false;


		if(spawner.stop == true){
			speed = 0;
		}
		
	}


	void Update(){
		transform.position = Vector2.MoveTowards(transform.position, planet.position, speed * Time.deltaTime);

		lineRend.SetPosition(0, transform.position);
		lineRend.SetPosition(1, planet.position);

		if(cantDieTime > 0){
			cantDieTime -= Time.deltaTime;
		}

	}


	void OnTriggerEnter2D(Collider2D other){
		if(playedSound == false){
			source.clip = squish;
			source.Play();
			playedSound = true;
		}

		if(other.CompareTag("Player")){
			speed = 0;
			this.gameObject.transform.parent = other.transform;

			if(spawner.startTimeBtwSpawns > 0.2f && hasDamaged == false){
				hasDamaged = true;
				spawner.startTimeBtwSpawns = spawner.startTimeBtwSpawns - spawner.decrement;
			}
		} else if(other.CompareTag("Slime")){
			
			speed = 0;
			this.gameObject.transform.parent = planet.transform;

			if(spawner.startTimeBtwSpawns > 0.2f && hasDamaged == false){
				hasDamaged = true;
				spawner.startTimeBtwSpawns = spawner.startTimeBtwSpawns - spawner.decrement;
			}

		}
		if(cantDieTime <= 0){
			lineRend.enabled = true;
		} 

	}

	public void Death(){
		player.Explode();
		spawner.score++;
		spawner.ScoreAnim();
		Instantiate(effect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

}
