﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TechTree : MonoBehaviour {

	public float baseIncome = 10;
	public float incomeRate = 1;
	public float wages = 0;
	public float profit = 0;
	public string incomeTitle = "INCOME<size=20>(py)</size>:";
	public string wagesTitle = "WAGES<size=20>(py)</size>:";
	public string profitTitle = "PROFIT:";
	public Text incomeText;
	public Text incomeNumber;
	public Text wagesText;
	public Text wagesNumber;
	public Text profitText;
	public Text profitNumber;
	public Color negativeProfitColor;
	public Color positiveProfitColor;
	private KeyCode buttonInteract;
	public Station[] stations;

	void Start () {
		profitNumber.text = profit.ToString();
		buttonInteract = KeyCode.Space;
		for(int i = 0; i < stations.Length; ++i) {
			stations[i].interactable = stations[i].target.GetComponent<StationObject>().interactable;		
		}
		SetStations();
		InvokeRepeating("ApplyProfitRate", 0f, 5f);
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

	void UpgradeStation (int i) {
		if (stations[i].level < stations[i].maxLevel){
			Debug.Log(stations[i].cost[stations[i].level]);
			profit -= stations[i].cost[stations[i].level];
			stations[i].level += 1;
			SpriteRenderer stationSprite = stations[i].target.GetComponent<SpriteRenderer>();
			stationSprite.sprite = stations[i].spriteLevel[stations[i].level];
			ProfitRate();
		}
	}

	void SetCashTextValue(float c, Text t){
		if (c < 0){
			t.text = "-$" + Mathf.Abs(c).ToString("F0");
			t.color = negativeProfitColor;
		} else if (c == 0){
			t.text = "$" + Mathf.Abs(c).ToString("F0");
			t.color = positiveProfitColor;
		} else {
			t.text = "$" + Mathf.Abs(c).ToString("F0");
		}
	}

	void ProfitRate(){
		float f = 1;
		for(int i = 0; i < stations.Length; ++i) {
			//if(stations[i].income[stations[i].level] != 0){
				f += stations[i].income[stations[i].level];
			//}
		}
		if (f != incomeRate){
			incomeRate = f;
		}
		SetCashTextValue(baseIncome*incomeRate, incomeNumber);
		SetCashTextValue(wages, wagesNumber);
		SetCashTextValue(profit, profitNumber);
	}

	void ApplyProfitRate(){
		profit += (baseIncome * incomeRate) - wages;
		ProfitRate();
	}

	void SetStations(){
		for(int i = 0; i < stations.Length; ++i){

			// Station 0
			if (i == 0){
				stations[i].name = "Blast Furnace";
				stations[i].level = 0;
				stations[i].maxLevel = 4;
				stations[i].cost = new float[stations[i].maxLevel+1];
				stations[i].income = new float[stations[i].maxLevel+1];
				stations[i].spriteLevel = new Sprite[stations[i].maxLevel+1];
				stations[i].spriteLevel[0] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/rock");
				stations[i].spriteLevel[1] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/barrel");
				stations[i].spriteLevel[2] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/chest");
				stations[i].spriteLevel[3] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/building-thin");
				stations[i].spriteLevel[4] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/Building");
				SpriteRenderer stationSprite = stations[i].target.GetComponent<SpriteRenderer>();
				stationSprite.sprite = stations[i].spriteLevel[stations[i].level];
				stations[i].cost[0] = 10;
				stations[i].cost[1] = 100;
				stations[i].cost[2] = 500;
				stations[i].cost[3] = 3000;
				stations[i].cost[4] = 10000;
				stations[i].income[0] = 0f;
				stations[i].income[1] = 1f;
				stations[i].income[2] = 4f;
				stations[i].income[3] = 10f;
				stations[i].income[4] = 40f;
			}

			// Station 1
			if (i == 1){
				stations[i].name = "Ladle Furnace";
				stations[i].level = 0;
				stations[i].maxLevel = 4;
				stations[i].cost = new float[stations[i].maxLevel+1];
				stations[i].income = new float[stations[i].maxLevel+1];
				stations[i].spriteLevel = new Sprite[stations[i].maxLevel+1];
				stations[i].spriteLevel[0] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/rock");
				stations[i].spriteLevel[1] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/barrel");
				stations[i].spriteLevel[2] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/chest");
				stations[i].spriteLevel[3] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/building-thin");
				stations[i].spriteLevel[4] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/Building");
				SpriteRenderer stationSprite = stations[i].target.GetComponent<SpriteRenderer>();
				stationSprite.sprite = stations[i].spriteLevel[stations[i].level];
				stations[i].cost[0] = 10;
				stations[i].cost[1] = 100;
				stations[i].cost[2] = 500;
				stations[i].cost[3] = 3000;
				stations[i].cost[4] = 10000;
				stations[i].income[0] = 0f;
				stations[i].income[1] = 1f;
				stations[i].income[2] = 4f;
				stations[i].income[3] = 10f;
				stations[i].income[4] = 40f;
			}

			// Station 2
			if (i == 2){
				stations[i].name = "Caster";
				stations[i].level = 0;
				stations[i].maxLevel = 4;
				stations[i].cost = new float[stations[i].maxLevel+1];
				stations[i].income = new float[stations[i].maxLevel+1];
				stations[i].spriteLevel = new Sprite[stations[i].maxLevel+1];
				stations[i].spriteLevel[0] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/rock");
				stations[i].spriteLevel[1] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/barrel");
				stations[i].spriteLevel[2] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/chest");
				stations[i].spriteLevel[3] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/building-thin");
				stations[i].spriteLevel[4] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/Building");
				SpriteRenderer stationSprite = stations[i].target.GetComponent<SpriteRenderer>();
				stationSprite.sprite = stations[i].spriteLevel[stations[i].level];
				stations[i].cost[0] = 10;
				stations[i].cost[1] = 100;
				stations[i].cost[2] = 500;
				stations[i].cost[3] = 3000;
				stations[i].cost[4] = 10000;
				stations[i].income[0] = 0f;
				stations[i].income[1] = 1f;
				stations[i].income[2] = 4f;
				stations[i].income[3] = 10f;
				stations[i].income[4] = 40f;
			}

			// Station 3
			if (i == 3){
				stations[i].name = "Reheat Furnace";
				stations[i].level = 0;
				stations[i].maxLevel = 4;
				stations[i].cost = new float[stations[i].maxLevel+1];
				stations[i].income = new float[stations[i].maxLevel+1];
				stations[i].spriteLevel = new Sprite[stations[i].maxLevel+1];
				stations[i].spriteLevel[0] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/rock");
				stations[i].spriteLevel[1] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/barrel");
				stations[i].spriteLevel[2] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/chest");
				stations[i].spriteLevel[3] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/building-thin");
				stations[i].spriteLevel[4] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/Building");
				SpriteRenderer stationSprite = stations[i].target.GetComponent<SpriteRenderer>();
				stationSprite.sprite = stations[i].spriteLevel[stations[i].level];
				stations[i].cost[0] = 10;
				stations[i].cost[1] = 100;
				stations[i].cost[2] = 500;
				stations[i].cost[3] = 3000;
				stations[i].cost[4] = 10000;
				stations[i].income[0] = 0f;
				stations[i].income[1] = 1f;
				stations[i].income[2] = 4f;
				stations[i].income[3] = 10f;
				stations[i].income[4] = 40f;
			}

			// Station 4
			if (i == 4){
				stations[i].name = "Coiler";
				stations[i].level = 0;
				stations[i].maxLevel = 4;
				stations[i].cost = new float[stations[i].maxLevel+1];
				stations[i].income = new float[stations[i].maxLevel+1];
				stations[i].spriteLevel = new Sprite[stations[i].maxLevel+1];
				stations[i].spriteLevel[0] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/rock");
				stations[i].spriteLevel[1] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/barrel");
				stations[i].spriteLevel[2] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/chest");
				stations[i].spriteLevel[3] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/building-thin");
				stations[i].spriteLevel[4] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/Building");
				SpriteRenderer stationSprite = stations[i].target.GetComponent<SpriteRenderer>();
				stationSprite.sprite = stations[i].spriteLevel[stations[i].level];
				stations[i].cost[0] = 10;
				stations[i].cost[1] = 100;
				stations[i].cost[2] = 500;
				stations[i].cost[3] = 3000;
				stations[i].cost[4] = 10000;
				stations[i].income[0] = 0f;
				stations[i].income[1] = 1f;
				stations[i].income[2] = 4f;
				stations[i].income[3] = 10f;
				stations[i].income[4] = 40f;
			}

			// Station 5
			if (i == 5){
				stations[i].name = "Cold Mill";
				stations[i].level = 0;
				stations[i].maxLevel = 4;
				stations[i].cost = new float[stations[i].maxLevel+1];
				stations[i].income = new float[stations[i].maxLevel+1];
				stations[i].spriteLevel = new Sprite[stations[i].maxLevel+1];
				stations[i].spriteLevel[0] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/rock");
				stations[i].spriteLevel[1] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/barrel");
				stations[i].spriteLevel[2] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/chest");
				stations[i].spriteLevel[3] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/building-thin");
				stations[i].spriteLevel[4] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/Building");
				SpriteRenderer stationSprite = stations[i].target.GetComponent<SpriteRenderer>();
				stationSprite.sprite = stations[i].spriteLevel[stations[i].level];
				stations[i].cost[0] = 10;
				stations[i].cost[1] = 100;
				stations[i].cost[2] = 500;
				stations[i].cost[3] = 3000;
				stations[i].cost[4] = 10000;
				stations[i].income[0] = 0f;
				stations[i].income[1] = 1f;
				stations[i].income[2] = 4f;
				stations[i].income[3] = 10f;
				stations[i].income[4] = 40f;
			}

			// Station 6
			if (i == 6){
				stations[i].name = "Pickling Line";
				stations[i].level = 0;
				stations[i].maxLevel = 4;
				stations[i].cost = new float[stations[i].maxLevel+1];
				stations[i].income = new float[stations[i].maxLevel+1];
				stations[i].spriteLevel = new Sprite[stations[i].maxLevel+1];
				stations[i].spriteLevel[0] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/rock");
				stations[i].spriteLevel[1] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/barrel");
				stations[i].spriteLevel[2] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/chest");
				stations[i].spriteLevel[3] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/building-thin");
				stations[i].spriteLevel[4] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/Building");
				SpriteRenderer stationSprite = stations[i].target.GetComponent<SpriteRenderer>();
				stationSprite.sprite = stations[i].spriteLevel[stations[i].level];
				stations[i].cost[0] = 10;
				stations[i].cost[1] = 100;
				stations[i].cost[2] = 500;
				stations[i].cost[3] = 3000;
				stations[i].cost[4] = 10000;
				stations[i].income[0] = 0f;
				stations[i].income[1] = 1f;
				stations[i].income[2] = 4f;
				stations[i].income[3] = 10f;
				stations[i].income[4] = 40f;
			}
		}
	}

}

[System.Serializable]
public class Station {
	public string name;
	public GameObject target;
	public int level;
	public int maxLevel;
	public Sprite[] spriteLevel;
	public float[] cost;
	public float[] income;
	public bool interactable = false;

	public Station(string newName, GameObject newTarget, int newLevel, int newMaxLevel, Sprite[] newSpriteLevel, float[] newCost, float[] newIncome, bool newInteractable) {
		name = newName;
		target = newTarget;
		level = newLevel;
		maxLevel = newMaxLevel;
		spriteLevel = newSpriteLevel;
		cost = newCost;
		income = newIncome;
		interactable = newInteractable;
	}
}
