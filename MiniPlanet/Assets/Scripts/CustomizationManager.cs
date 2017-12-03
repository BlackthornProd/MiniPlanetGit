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

	void Start(){

		visuals = GameObject.FindGameObjectWithTag("Visuals").GetComponent<VisualDetector>();
	}

	void Update(){

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

		SceneManager.LoadScene("Game");
	}
}
