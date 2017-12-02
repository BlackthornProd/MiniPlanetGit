using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protection : MonoBehaviour {

	private Shake shake;

	void Start(){

		shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Shake>();
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Slime")){
			shake.Shaker(0.125f, 0.125f);
			other.GetComponent<Slime>().Death();
		}
	}
}
