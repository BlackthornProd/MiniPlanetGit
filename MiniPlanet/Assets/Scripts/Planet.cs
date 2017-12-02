using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

	public float speed;


	void Update(){

		if(Input.GetKey(KeyCode.LeftArrow)){	
			transform.Rotate(Vector3.forward * speed * Time.deltaTime);
		} else if(Input.GetKey(KeyCode.RightArrow)){
			transform.Rotate(Vector3.forward * -speed * Time.deltaTime);
		} 
	}
}
