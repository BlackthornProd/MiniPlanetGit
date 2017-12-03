using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomizationManager : MonoBehaviour {

	public int currentIndex;
	public int maxIndex;

	public Sprite[] characters;
	public SpriteRenderer rend;
	private VisualDetector visuals;
	private CustomizationManager customization;

	public Animator fadePanel;

	public bool unlocked;
	public Sprite sun;

	public AudioSource source;
	public AudioClip click;
	public AudioClip squish;

	void Start(){
		source = GetComponent<AudioSource>();
		source.clip = click;
		visuals = GameObject.FindGameObjectWithTag("Visuals").GetComponent<VisualDetector>();
		fadePanel.SetTrigger("FadeOut");

		visuals.unlockedScene = false;
	}

	void Update(){
		if(visuals.unlocked == true){
			unlocked = true;
		}

		if(unlocked == true){
			characters[8] = sun;
		}

		visuals.visual = currentIndex;

		for (int i = 0; i < characters.Length; i++) {
			if(i == currentIndex){
				//characters[i].SetActive(true);
				rend.sprite = characters[i];
			} 
		}	
	}


	public void ChangeIndex(){
		source.clip = squish;
		source.Play();
		if(currentIndex < maxIndex){
			currentIndex++;
		} else {
			currentIndex = 0;
		}

	}

	public void Play(){
		source.clip = click;
		source.Play();
		if(currentIndex == 8 && unlocked == true){
			StartCoroutine(GoToPlay());
		} else if(currentIndex != 8 )
		{
			StartCoroutine(GoToPlay());
		}

	}

	IEnumerator GoToPlay(){

		fadePanel.SetTrigger("FadeIn");
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene("Game");
	}
}
