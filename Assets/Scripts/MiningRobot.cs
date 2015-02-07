using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MiningRobot : Robot {
	public Vector3 movingSpeed;
	public float miningRate = 1.0f;
	//Robot with specialty mines its specialty type faster
	public int specializeInType = (int)ResourceType.DEFAULT;
	public float miningRateMultiplier = 1.1f;

	public GameObject ownerRefinery;
	public Queue<TerrainTile> miningJobs;

	public int initRadius = 3;
	//TODO: add mining focus
	public override void Awake(){
		base.Awake();
		upperLimit = 300;
		miningJobs = new Queue<TerrainTile>();
	}
	void Start () {
		terrain = Terrain.activeTerrain;
		level = 0;
		type = (int)RobotType.Mining;
		movingSpeed = new Vector3(5.0f, 0.0f, 5.0f);

	}

	void Update () {
		FindMineTile();
	}

	//BFS
	//find richest tile within a radius
	void FindMineTile(){
		//if no mining focus
		//if already has jobs
		if(miningJobs.Count > 0)return;
		//for real

		//int x = ownerRefinery.GetComponent<Refinery>().tileIdx_x;
		//int z = ownerRefinery.GetComponent<Refinery>().tileIdx_z;

		//for debug
		int x = 8;
		int z = 12;
		
		int startX = (int)Mathf.Max(0, x-initRadius);
		int endX = (int)Mathf.Min(x+initRadius, TerrainScript.myTerrain.tiles.GetLength(0));
		int startZ = (int)Mathf.Max(0, z-initRadius);
		int endZ = (int)Mathf.Min(z+initRadius, TerrainScript.myTerrain.tiles.GetLength(1));

		Debug.Log("x: " + startX + "-" + endX);
		Debug.Log("z: " + startZ + "-" + endZ);
		List<TerrainTile> tempTiles = new List<TerrainTile>();
		//find richest tile within this radius
		for(int i=startX; i<endX;i++){
			for(int j=startZ; j<endZ;j++){
				tempTiles.Add(TerrainScript.myTerrain.tiles[i,j].GetComponent<TerrainTile>());
			}
		}
		//note: this is descending
		tempTiles.Sort();
		/*
		for(int i=tempTiles.Count-1; i>=0;i--){
			Debug.Log(i + ": " +tempTiles[i].iron);
		}
		*/
		miningJobs = new Queue<TerrainTile>(tempTiles);
	}
}
