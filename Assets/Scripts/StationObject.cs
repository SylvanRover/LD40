using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationObject : MonoBehaviour {

	public TechTree techTree;
	private SpriteRenderer mySpriteRenderer;
	public bool interactable = false;
	public Sprite[] spriteLevels;

	void Start(){
		mySpriteRenderer = GetComponent<SpriteRenderer>();
		SpriteLevel(0);
	}

	void OnTriggerEnter2D(Collider2D col){	
		if(col.gameObject.tag == "Player") {
			mySpriteRenderer.color = Color.red;
			interactable = true;
		}
	}
	void OnTriggerExit2D(Collider2D col){	
		if(col.gameObject.tag == "Player") {
			mySpriteRenderer.color = Color.white;
			interactable = false;
		}
	}

	public void SpriteLevel(int i){
		mySpriteRenderer.sprite = spriteLevels[i];
	}

}
