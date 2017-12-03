using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualDetector : MonoBehaviour {

	private static VisualDetector instance;

	public int visual;

	void Awake(){

		if(instance == null){
			instance = this;
			DontDestroyOnLoad(this);
		} else {

			Destroy(gameObject);
		}
	}


}
