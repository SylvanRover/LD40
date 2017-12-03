using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationObject : MonoBehaviour {
	
	private SpriteRenderer mySpriteRenderer;
	public bool interactable = false;
	public Transform workerSpawn;
	public bool jobFull = false;

	void Start(){
		mySpriteRenderer = GetComponent<SpriteRenderer>();
	}

	void SpawnWorker(GameObject worker){
		Instantiate(worker);
		worker.transform.position = workerSpawn.position;
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
}
