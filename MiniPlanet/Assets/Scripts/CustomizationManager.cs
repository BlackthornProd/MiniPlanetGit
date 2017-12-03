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

	void Start(){

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
		if(currentIndex < maxIndex){
			currentIndex++;
		} else {
			currentIndex = 0;
		}

	}

	public void Play(){

		if(currentIndex != 8 && unlocked == false){
			StartCoroutine(GoToPlay());
		}

	}

	IEnumerator GoToPlay(){

		fadePanel.SetTrigger("FadeIn");
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene("Game");
	}
}
