using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public float baseIncome = 10;
	public float incomeRate = 1;
	public float tempIncomeRate = 1;
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
	private KeyCode buttonHire;
	public Station[] stations;
	public string workerName = "Worker_01";

	void Start () {
		profitNumber.text = profit.ToString();
		buttonInteract = KeyCode.Space;
		buttonHire = KeyCode.Return;
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
		if (Input.GetKeyDown(buttonHire)){
			for(int i = 0; i < stations.Length; ++i){
				stations[i].interactable = stations[i].target.GetComponent<StationObject>().interactable;
				if (stations[i].interactable){
					UpgradeWorker(i, workerName);
				}				
			}
		}
	}

	void UpgradeStation (int i) {
		if (stations[i].level < stations[i].maxLevel){
			profit -= stations[i].cost[stations[i].level];
			stations[i].level += 1;
			SpriteRenderer stationSprite = stations[i].target.GetComponent<SpriteRenderer>();
			stationSprite.sprite = stations[i].spriteLevel[stations[i].level];
			ProfitRate();
		}
	}

	void UpgradeWorker(int i, string w){
			StationObject stationObject = stations[i].target.GetComponent<StationObject>();
		if (stations[i].target.GetComponent<StationObject>().workerSpawn != null){
			if (!stationObject.jobFull){
				GameObject worker = Instantiate(Resources.Load<GameObject>("Prefabs/" + w));
				WorkerObject workerObject = worker.GetComponent<WorkerObject>();
				worker.transform.position = stationObject.workerSpawn.position;
				worker.transform.parent = stationObject.workerSpawn;
				stationObject.jobFull = true;
				workerObject.id = i;
				ProfitRate();
			}
		}
	}

	void ProfitRate(){
		
		float f = 0;

		for(int i = 0; i < stations.Length; ++i) {
			f += stations[i].income[stations[i].level];
		}
		if (f != baseIncome){
			baseIncome = f;
		}
		GameObject[] worker = GameObject.FindGameObjectsWithTag("Worker");
		float tempIncomeRate = 1;
		for(int i = 0; i < worker.Length; ++i) {
			WorkerObject workerObject = worker[i].GetComponent<WorkerObject>();
			workerObject.SetWorker(workerObject.id);
			tempIncomeRate += workerObject.income[workerObject.level];
		}
		if (tempIncomeRate != incomeRate){
				incomeRate = tempIncomeRate;
				baseIncome *= incomeRate;
				Debug.Log("Income Rate is " + baseIncome);
				Debug.Log("Temp is " + tempIncomeRate);
		}

		SetCashTextValue(baseIncome*=incomeRate, incomeNumber);
		SetCashTextValue(wages, wagesNumber);
		SetCashTextValue(profit, profitNumber);
	}

	void ApplyProfitRate(){
		profit += (baseIncome - wages);
		ProfitRate();
	}

	void SetCashTextValue(float c, Text t){
		if (c < 0){
			t.text = "-$" + Mathf.Abs(c).ToString("F2");
			t.color = negativeProfitColor;
		} else if (c == 0){
			t.text = "$" + Mathf.Abs(c).ToString("F2");
			t.color = positiveProfitColor;
		} else {
			t.text = "$" + Mathf.Abs(c).ToString("F2");
		}
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
	void SetWorkers(){
		for(int i = 0; i < stations.Length; ++i){

			// Station 0
			if (i == 0){
				stations[i].name = "Laborer";
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
				stations[i].income[1] = 0.1f;
				stations[i].income[2] = 0.4f;
				stations[i].income[3] = 1f;
				stations[i].income[4] = 4f;
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

[System.Serializable]
public class Worker {
	public string name;
	public int id;
	public GameObject target;
	public int level;
	public int maxLevel;
	public Sprite[] spriteLevel;
	public float[] cost;
	public float[] income;
	public bool interactable = false;

	public Worker(string newName, int newId, GameObject newTarget, int newLevel, int newMaxLevel, Sprite[] newSpriteLevel, float[] newCost, float[] newIncome, bool newInteractable) {
		name = newName;
		id = newId;
		target = newTarget;
		level = newLevel;
		maxLevel = newMaxLevel;
		spriteLevel = newSpriteLevel;
		cost = newCost;
		income = newIncome;
		interactable = newInteractable;
	}
}