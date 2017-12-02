using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TechTree : MonoBehaviour {

	public float income = 0;
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
	private KeyCode buttonInteract;
	public Station[] stations;

	void Start () {
		profitNumber.text = profit.ToString();
		buttonInteract = KeyCode.Space;
		for(int i = 0; i < stations.Length; ++i) {
			stations[i].interactable = stations[i].target.GetComponent<StationObject>().interactable;		
		}
		SetStations();
		InvokeRepeating("ProfitRate", 0f, 5f);
	}

	void UpgradeStation (int i) {
		var stationLevel = stations[i].level;
		stationLevel += 1;
		var stationObject = stations[i].target.GetComponent<StationObject>();
		stationObject.SpriteLevel(stations[i].level);
		profit -= stations[i].cost[stationLevel];
		if (profit < 0){
			profitNumber.text = "-$" + Mathf.Abs(profit).ToString();
			profitNumber.color = negativeProfitColor;
		} else if (profit == 0){
			profitNumber.text = "$" + Mathf.Abs(profit).ToString();
			profitNumber.color = negativeProfitColor;
		} else {
			profitNumber.text = "$" + Mathf.Abs(profit).ToString();
		}
		profitText.text = profitTitle + ": ";
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


	void ProfitRate(){
		for(int i = 0; i < stations.Length; ++i) {			
			income += stations[i].income[stations[i].level];
		}
		Debug.Log("Income is " + income);
		Debug.Log("Wages are " + wages);
		Debug.Log("Profit is " + profit);
		profit = profit + income - wages;
		incomeNumber.text = income.ToString();
		wagesNumber.text = wages.ToString();
		profitNumber.text = profit.ToString();
	}

	void SetStations(){
		for(int i = 0; i < stations.Length; ++i){

			// Station 0
			if (i == 0){
				stations[i].name = "Blast Furnace";
				stations[i].level = 0;
				stations[i].maxLevel = 5;
				stations[i].cost = new float[stations[i].maxLevel];
				stations[i].income = new float[stations[i].maxLevel];
				stations[i].cost[0] = 10;
				stations[i].cost[1] = 100;
				stations[i].cost[2] = 500;
				stations[i].cost[3] = 3000;
				stations[i].cost[4] = 10000;
				stations[i].income[0] = 0f;
				stations[i].income[1] = 0.5f;
				stations[i].income[2] = 4f;
				stations[i].income[3] = 10f;
				stations[i].income[4] = 40f;
			}

			// Station 1
			if (i == 1){
				stations[i].name = "Ladle Furnace";
				stations[i].level = 0;
				stations[i].maxLevel = 5;
				stations[i].cost = new float[stations[i].maxLevel];
				stations[i].income = new float[stations[i].maxLevel];
				stations[i].cost[0] = 10;
				stations[i].cost[1] = 100;
				stations[i].cost[2] = 500;
				stations[i].cost[3] = 3000;
				stations[i].cost[4] = 10000;
				stations[i].income[0] = 0f;
				stations[i].income[1] = 0.5f;
				stations[i].income[2] = 4f;
				stations[i].income[3] = 10f;
				stations[i].income[4] = 40f;
			}

			// Station 2
			if (i == 2){
				stations[i].name = "Caster";
				stations[i].level = 0;
				stations[i].maxLevel = 5;
				stations[i].cost = new float[stations[i].maxLevel];
				stations[i].income = new float[stations[i].maxLevel];
				stations[i].cost[0] = 10;
				stations[i].cost[1] = 100;
				stations[i].cost[2] = 500;
				stations[i].cost[3] = 3000;
				stations[i].cost[4] = 10000;
				stations[i].income[0] = 0f;
				stations[i].income[1] = 0.5f;
				stations[i].income[2] = 4f;
				stations[i].income[3] = 10f;
				stations[i].income[4] = 40f;
			}

			// Station 3
			if (i == 3){
				stations[i].name = "Reheat Furnace";
				stations[i].level = 0;
				stations[i].maxLevel = 5;
				stations[i].cost = new float[stations[i].maxLevel];
				stations[i].income = new float[stations[i].maxLevel];
				stations[i].cost[0] = 10;
				stations[i].cost[1] = 100;
				stations[i].cost[2] = 500;
				stations[i].cost[3] = 3000;
				stations[i].cost[4] = 10000;
				stations[i].income[0] = 0f;
				stations[i].income[1] = 0.5f;
				stations[i].income[2] = 4f;
				stations[i].income[3] = 10f;
				stations[i].income[4] = 40f;
			}

			// Station 4
			if (i == 4){
				stations[i].name = "Coiler";
				stations[i].level = 0;
				stations[i].maxLevel = 5;
				stations[i].cost = new float[stations[i].maxLevel];
				stations[i].income = new float[stations[i].maxLevel];
				stations[i].cost[0] = 10;
				stations[i].cost[1] = 100;
				stations[i].cost[2] = 500;
				stations[i].cost[3] = 3000;
				stations[i].cost[4] = 10000;
				stations[i].income[0] = 0f;
				stations[i].income[1] = 0.5f;
				stations[i].income[2] = 4f;
				stations[i].income[3] = 10f;
				stations[i].income[4] = 40f;
			}

			// Station 5
			if (i == 5){
				stations[i].name = "Cold Mill";
				stations[i].level = 0;
				stations[i].maxLevel = 5;
				stations[i].cost = new float[stations[i].maxLevel];
				stations[i].income = new float[stations[i].maxLevel];
				stations[i].cost[0] = 10;
				stations[i].cost[1] = 100;
				stations[i].cost[2] = 500;
				stations[i].cost[3] = 3000;
				stations[i].cost[4] = 10000;
				stations[i].income[0] = 0f;
				stations[i].income[1] = 0.5f;
				stations[i].income[2] = 4f;
				stations[i].income[3] = 10f;
				stations[i].income[4] = 40f;
			}

			// Station 6
			if (i == 6){
				stations[i].name = "Pickling Line";
				stations[i].level = 0;
				stations[i].maxLevel = 5;
				stations[i].cost = new float[stations[i].maxLevel];
				stations[i].income = new float[stations[i].maxLevel];
				stations[i].cost[0] = 10;
				stations[i].cost[1] = 100;
				stations[i].cost[2] = 500;
				stations[i].cost[3] = 3000;
				stations[i].cost[4] = 10000;
				stations[i].income[0] = 0f;
				stations[i].income[1] = 0.5f;
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
	public float[] cost;
	public float[] income;
	public bool interactable = false;

	public Station(string newName, GameObject newTarget, int newLevel, int newMaxLevel, float[] newCost, float[] newIncome, bool newInteractable) {
		name = newName;
		target = newTarget;
		level = newLevel;
		maxLevel = newMaxLevel;
		cost = newCost;
		income = newIncome;
		interactable = newInteractable;
	}
}
