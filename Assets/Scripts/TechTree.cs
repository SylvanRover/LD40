using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Station {
	public string name;
	public int level;
	public int cost;
	public GameObject target;
	public bool interactable = false;

	public Station(string newName, int newLevel, int newCost, GameObject newTarget, bool newInteractable) {
		name = newName;
		level = newLevel;
		cost = newCost;
		target = newTarget;
		interactable = newInteractable;
	}
}

public class TechTree : MonoBehaviour {

	public Station[] stations;
	public float cash = 0;
	public Text cashText;
	private KeyCode buttonInteract;
	public string cashTitle = "Cash: $";

	void Start () {
		cashText.text = "Cash: $" + cash.ToString();
		buttonInteract = KeyCode.Space;
		for(int i = 0; i < stations.Length; ++i){
			stations[i].interactable = stations[i].target.GetComponent<StationObject>().interactable;		
		}
	}

	void UpgradeStation (int i) {
		if (cash >= stations[i].cost){
			cash = cash - stations[i].cost;
			cashText.text = cashTitle + cash.ToString();
			stations[i].level = stations[i].level + 1;
			var stationObject = stations[i].target.GetComponent<StationObject>();
			stationObject.SpriteLevel(stations[i].level);
			Debug.Log(stationObject + " Level " + stations[i].level);
		}
	}

	void Update(){
		if (Input.GetKeyDown(buttonInteract)){
			for(int i = 0; i < stations.Length; ++i){
				stations[i].interactable = stations[i].target.GetComponent<StationObject>().interactable;
				if (stations[i].interactable){
					UpgradeStation(i);
				}				
			}
		}
	}

}
