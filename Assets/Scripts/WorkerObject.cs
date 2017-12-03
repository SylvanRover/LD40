using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerObject : MonoBehaviour {

	public GameController gameController;
	private Worker[] worker;
	public string name = "Laborer";
	public int id;
	public int level = 0;
	public int maxLevel = 4;
	public float[] cost;
	public float[] income;
	public Sprite[] spriteLevel;

	void SetWorker(){
		spriteLevel[0] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/rock");
		spriteLevel[1] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/barrel");
		spriteLevel[2] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/chest");
		spriteLevel[3] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/building-thin");
		spriteLevel[4] = Resources.Load<Sprite>("TinyRPGTown/Artwork/Sprites/Building");
		SpriteRenderer stationSprite = GetComponent<SpriteRenderer>();
		stationSprite.sprite = spriteLevel[level];
		cost[0] = 10;
		cost[1] = 100;
		cost[2] = 500;
		cost[3] = 3000;
		cost[4] = 10000;
		income[0] = 0f;
		income[1] = 0.1f;
		income[2] = 0.4f;
		income[3] = 1f;
		income[4] = 4f;
	}
	
	
}