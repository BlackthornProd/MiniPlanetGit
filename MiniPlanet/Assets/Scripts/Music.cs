using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

	private static Music instance;

	void Awake(){

		if(instance == null){
			instance = this;
			DontDestroyOnLoad(instance);
		} else {
			Destroy(gameObject);
		}
	}
}
