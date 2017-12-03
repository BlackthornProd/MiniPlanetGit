using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour {

	[Header ("References")]
	public Transform[] poses;
	public GameObject[] slimes;
	public int score = 0;
	public Text scoreDisplay;
	public Text highscoreDisplay;
	public Animator scoreAnim;
	public Animator fadePanel;

	[Header ("Difficulty stats")]
	private float timeBtwSpawns;
	public float startTimeBtwSpawns;
	public float decrement;

	public bool stop = false;

	private VisualDetector visuals;

	void Start(){
		visuals = GameObject.FindGameObjectWithTag("Visuals").GetComponent<VisualDetector>();
		visuals.unlockedScene = true;
		timeBtwSpawns = startTimeBtwSpawns;
		fadePanel.SetTrigger("FadeOut");
	}

	void Update(){

		scoreDisplay.text = "Yourself | " + score;

		Debug.Log(startTimeBtwSpawns);

		if(timeBtwSpawns <= 0){
			int rand = Random.Range(0, poses.Length);
			int randSlime = Random.Range(0, slimes.Length);
			Instantiate(slimes[randSlime], poses[rand].position, Quaternion.identity);
			timeBtwSpawns = startTimeBtwSpawns;
		} else {
			timeBtwSpawns -= Time.deltaTime;
		}



		if(score > PlayerPrefs.GetInt("HighScore", 0)){
			PlayerPrefs.SetInt("HighScore", score);
		}

		highscoreDisplay.text = "Best | " + PlayerPrefs.GetInt("HighScore");

		if(Input.GetKeyDown(KeyCode.Space)){
			SceneManager.LoadScene("MainMenu");
		}
	}

	public void ScoreAnim(){
		scoreAnim.SetTrigger("Yourself");
	}

	public void StartRout(){
		StartCoroutine(BackToMenu());
	}

	IEnumerator BackToMenu(){

		yield return new WaitForSeconds(3.5f);
		fadePanel.SetTrigger("FadeIn");
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene("MainMenu");
	}
}
