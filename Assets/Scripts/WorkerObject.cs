using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerObject : MonoBehaviour {
	
	private Dictionary<string,Sprite> sprites;

	public GameController gameController;
	private Worker[] worker;
	public string name = "Laborer";
	public int id;
	public int level = 0;
	public int maxLevel = 4;
	public float[] cost;
	public float[] income;
	public Sprite[] spriteLevel;

	private void LoadDictionary() {
		Sprite[] SpritesData = Resources.LoadAll<Sprite>("TinyRPGTown/Artwork/Sprites/npc");
		sprites = new Dictionary<string, Sprite>();

		for (int i = 0; i < SpritesData.Length; i++) {
			sprites.Add(SpritesData[i].name, SpritesData[i]);
		}
	}

	public Sprite GetSpriteByName(string name) {
		if (sprites.ContainsKey(name))
			return sprites[name];
		else 
			return null;
	}

	public void SetWorker(int i){	
		LoadDictionary();	
		cost = new float[maxLevel+1];
		income = new float[maxLevel+1];
		spriteLevel = new Sprite[maxLevel+1];
		spriteLevel[0] = GetSpriteByName("npc_0");
		spriteLevel[1] = GetSpriteByName("npc_3");
		spriteLevel[2] = GetSpriteByName("npc_6");
		spriteLevel[3] = GetSpriteByName("npc_9");
		spriteLevel[4] = GetSpriteByName("npc_12");
		SpriteRenderer stationSprite = GetComponent<SpriteRenderer>();
		stationSprite.sprite = spriteLevel[level];
		cost[0] = 10;
		cost[1] = 100;
		cost[2] = 500;
		cost[3] = 3000;
		cost[4] = 10000;
		income[0] = 0.5f;
		income[1] = 0.4f;
		income[2] = 1f;
		income[3] = 4f;
		income[4] = 10f;
	}	
}