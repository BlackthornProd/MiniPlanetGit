using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

	public GameObject[] panels;
	public int currentPanel;
	public Animator FadePanel;

	private AudioSource source;
	public AudioClip click;

	void Start(){
		source = GetComponent<AudioSource>();
		FadePanel.SetTrigger("FadeOut");
	}


	void Update(){

		if(Input.anyKeyDown || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)){

			NextPanel();
		}

		for (int i = 0; i < panels.Length; i++) {
			if(i == currentPanel){
				panels[i].SetActive(true);
			}
		}

		if(currentPanel == 6){
			StartCoroutine(LoadMenu());
		}
	}

	public void NextPanel(){
		source.clip = click;
		source.Play();
		currentPanel++;
	}

	IEnumerator LoadMenu(){

		yield return new WaitForSeconds(6.5f);
		FadePanel.SetTrigger("FadeIn");
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene("MainMenu");
	}
}
