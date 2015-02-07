﻿
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainScript : MonoBehaviour {
	public static TerrainScript myTerrain;

	[HideInInspector]public Terrain t;
	public Planet planet;
	public GameObject tilePrefab;

 	public GameObject player;
 	public Camera playerCam;
 	public GameObject selectedAreaProj; 
 	public GameObject[,] tiles;

 	private Vector3 terrainSize;
 	private TerrainData terrain_Data;
 	private int gridNum_X;
 	private int gridNum_Z;
 	[HideInInspector]public static float tileLeng = 50.0f;


 	void Awake(){
 		terrain_Data = gameObject.GetComponent<TerrainCollider>().terrainData;
		terrainSize = gameObject.GetComponent<TerrainCollider>().terrainData.size;

		gridNum_X = (int)Mathf.Floor(terrainSize.x / tileLeng);
		gridNum_Z = (int)Mathf.Floor(terrainSize.z / tileLeng);
		tiles = new GameObject[gridNum_X,gridNum_Z];
		myTerrain = this;
		//Debug.Log(tiles.Length);
 	}
	void Start () {
		if(planet == null)planet = new IronPlanet();
		SliceTerrain();
		DistributeResources();
	}
	
	void Update () {
	
	}
	//slice the terrain into square tiles
	void SliceTerrain(){
		
		
		Vector3 spawnPos = new Vector3(0,0,0);

		for(int i=0; i < gridNum_X; i++){
			spawnPos.x = i*tileLeng+0.5f*tileLeng;
			for(int j=0; j < gridNum_Z; j++){
				spawnPos.z = j*tileLeng+0.5f*tileLeng;

				GameObject terrainTile 
					= Instantiate(tilePrefab, spawnPos ,Quaternion.identity)
					as GameObject;
				tiles[i,j] = terrainTile;
				//Debug.Log(tiles[i,j]);
			}
		}
	}
	void DistributeResources(){
		int totalIron = 0;
		for(int i=0; i < gridNum_X; i++){
			for(int j=0;j < gridNum_Z;j++){
				
				float center_X = tiles[i,j].transform.position.x;
				float center_Z = tiles[i,j].transform.position.z;
				//get altitude
				Vector3 groundLevelPoint = new Vector3(center_X, 0, center_Z);
				Vector3 up =  transform.TransformDirection(Vector3.up); 
				RaycastHit hitInfo;
				bool hit = Physics.Raycast(groundLevelPoint, up, out hitInfo);
				Vector3 hitPoint = hitInfo.point;
				float altitude = Terrain.activeTerrain.SampleHeight(hitPoint);

				float perlinVal = Mathf.PerlinNoise(
					Random.Range(center_X-tileLeng, center_X+tileLeng), 
					Random.Range(center_Z-tileLeng, center_Z+tileLeng)
					);
				totalIron += AssignResources(perlinVal, altitude, ref hitPoint, ref tiles[i,j]);

			}
		}
		//Debug.Log("iron: " + tiles[0,0].iron + "copper: " + tiles[0,0].copper);
		Debug.Log("Total Iron: " + totalIron);
	}

	int AssignResources(float perlinVal, float altitude, 
		ref Vector3 centerPt, ref GameObject tt){

		switch(planet.planetType){
			case (int)PlanetType.Carbon:
				break;
			case (int)PlanetType.Iron:
				//Iron
				if(perlinVal > 0.7f){
					tt.GetComponent<TerrainTile>().iron = Random.Range(1, 50);
					return 1;
				}
				break;
			default:
				break;
		}
		return 0;
	}

}