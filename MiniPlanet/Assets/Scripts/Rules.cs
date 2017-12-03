using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : MonoBehaviour {

	public GameObject rulePage;
	public Animator rulesAnim;

	private CustomizationManager manager;

	void Start(){

		manager = GameObject.FindGameObjectWithTag("CustomizationManager").GetComponent<CustomizationManager>();

	}

	public void GoRules(){
		manager.source.clip = manager.click;
		manager.source.Play();
		rulePage.SetActive(true);
		rulesAnim.SetBool("Visible", true);
	}

	public void LeaveRules(){
		manager.source.Play();
		StartCoroutine(HideRules());
	}

	IEnumerator HideRules(){

		rulesAnim.SetBool("Visible", false);
		yield return new WaitForSeconds(.75f);
		rulePage.SetActive(false);
	}
}
