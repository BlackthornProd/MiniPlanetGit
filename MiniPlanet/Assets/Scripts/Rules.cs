using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : MonoBehaviour {

	public GameObject rulePage;
	public Animator rulesAnim;

	public void GoRules(){

		rulePage.SetActive(true);
		rulesAnim.SetBool("Visible", true);
	}

	public void LeaveRules(){

		StartCoroutine(HideRules());
	}

	IEnumerator HideRules(){

		rulesAnim.SetBool("Visible", false);
		yield return new WaitForSeconds(1f);
		rulePage.SetActive(false);
	}
}
