using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro1 : MonoBehaviour {

	public Animator panel;

	void Start(){

		panel.SetTrigger("FadeOut");
		StartCoroutine(Title());
	}


	IEnumerator Title(){

		yield return new WaitForSeconds(3f);
		panel.SetTrigger("FadeIn");
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene("Intro");
	}

}
