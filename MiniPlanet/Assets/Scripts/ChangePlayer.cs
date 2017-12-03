using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour {

	private VisualDetector visuals;
	private SpriteRenderer rend;
	public Sprite[] heads;


	void Start(){
		visuals = GameObject.FindGameObjectWithTag("Visuals").GetComponent<VisualDetector>();
		rend = GetComponent<SpriteRenderer>();
		rend.sprite = heads[visuals.visual];
	}


}
