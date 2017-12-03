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
	public Animator scoreAnim;
	public Animator fadePanel;

	[Header ("Difficulty stats")]
	private float timeBtwSpawns;
	public float startTimeBtwSpawns;
	public float decrement;

	void Start(){

		timeBtwSpawns = startTimeBtwSpawns;
	}

	void Update(){

		scoreDisplay.text = "Yourself - " + score;

		Debug.Log(startTimeBtwSpawns);

		if(timeBtwSpawns <= 0){
			int rand = Random.Range(0, poses.Length);
			int randSlime = Random.Range(0, slimes.Length);
			Instantiate(slimes[randSlime], poses[rand].position, Quaternion.identity);
			timeBtwSpawns = startTimeBtwSpawns;
		} else {
			timeBtwSpawns -= Time.deltaTime;
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
