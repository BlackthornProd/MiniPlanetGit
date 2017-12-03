using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VisualDetector : MonoBehaviour {

	private static VisualDetector instance;
	private Spawner spawner;

	public int visual;
	public bool unlocked = false;

	public bool unlockedScene = false;
	void Awake(){

		if(instance == null){
			instance = this;
			DontDestroyOnLoad(instance);
		} else {

			Destroy(gameObject);
		}
	}

	void Start(){

	
		
	}

	void Update(){
			/*if(unlockedScene == true){
				spawner = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<Spawner>();
				if(spawner.score > 100){
					unlocked = true;
				}
			}*/

	}
}
