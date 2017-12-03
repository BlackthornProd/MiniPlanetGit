using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class About : MonoBehaviour {

	public GameObject about;
	public Animator anim;

	private bool inside = false;

	public void Go(){
		if(inside == false){
			AboutPage();
		} else {
			AboutPageOut();
		}
		
	}

	public void AboutPage(){

		about.SetActive(true);
		anim.SetTrigger("In");
		inside = true;
	}

	public void AboutPageOut(){
		StartCoroutine(Out());
		
	}

	IEnumerator Out(){
		inside = false;
		anim.SetTrigger("Out");
		yield return new WaitForSeconds(0.1f);
		about.SetActive(false);
	}
}
