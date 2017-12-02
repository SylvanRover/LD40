using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Station {
	public string name;
	public int level;
	public int cost;
	public GameObject target;

	public Station(string newName, int newLevel, int newCost, GameObject newTarget) {
		name = newName;
		level = newLevel;
		cost = newCost;
		target = newTarget;
	}
}

public class TechTree : MonoBehaviour {

	public Station[] stations;
	public float cash = 0;

	void Start () {
		
	}

	void UpgradeStation (int i) {
		if (cash >= stations[i].cost){
			cash = cash - stations[i].cost;
		}
	}
}
