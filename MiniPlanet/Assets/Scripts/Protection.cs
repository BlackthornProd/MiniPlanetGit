using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protection : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Slime")){
			other.GetComponent<Slime>().Death();
			Destroy(other.gameObject);
		}
	}
}
