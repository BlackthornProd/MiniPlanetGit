using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class About : MonoBehaviour {

	public GameObject about;
	public Animator anim;

	private bool inside = false;

	private CustomizationManager manager;

	void Start(){

		manager = GameObject.FindGameObjectWithTag("CustomizationManager").GetComponent<CustomizationManager>();

	}

	public void Go(){
		manager.source.clip = manager.click;
		manager.source.Play();
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
