﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

	private Spawner spawner;
	private Planet player;
	public GameObject redCircle;
	public Animator panelRed;
	public Animator fadePanel;



	void Start(){
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Planet>();
		spawner = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<Spawner>();
	}


	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Slime")){
			if(other.GetComponent<Slime>().cantDieTime <= 0){
				panelRed.enabled = true;
				spawner.enabled = false;
				player.enabled = false;
				spawner.stop = true;
				Instantiate(redCircle, other.transform.position, Quaternion.identity);
				spawner.StartRout();
			}
		
		}	
	}


}
