﻿
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainScript : MonoBehaviour {
	
	[HideInInspector]public Terrain t;
	public Planet planet;
	
 	public GameObject player;
 	public Camera playerCam;
 	public GameObject selectedAreaProj; 
 	[HideInInspector]public TerrainTile[,] tiles;

 	private Vector3 terrainSize;
 	private TerrainData terrain_Data;
 	private int gridNum_X;
 	private int gridNum_Z;
 	private float tileLeng = 50.0f;


 	void Awake(){
 		terrain_Data = gameObject.GetComponent<TerrainCollider>().terrainData;
		terrainSize = gameObject.GetComponent<TerrainCollider>().terrainData.size;
 	}
	void Start () {
		//init lists
		//refineries = new List<Refinery>();
		if(planet == null)planet = new IronPlanet();
		SliceTerrain();
		DistributeResources();
	}
	
	void Update () {
	
	}
	//slice the terrain into square tiles
	void SliceTerrain(){
		gridNum_X = (int)Mathf.Ceil(terrainSize.x / tileLeng);
		gridNum_Z = (int)Mathf.Ceil(terrainSize.z / tileLeng);
		tiles = new TerrainTile[gridNum_X,gridNum_Z];

		for(int i=0; i < gridNum_X; i++){
			for(int j=0; j < gridNum_Z; j++){
				tiles[i,j] = new TerrainTile();
			}
		}
		//Debug.Log("tile len: " + gridNum_X + ", " + tiles.Length);
	}
	void DistributeResources(){
		int totalIron = 0;
		for(int i=0; i < gridNum_X; i++){
			for(int j=0;j < gridNum_Z;j++){
				Vector3 tileCenter;
				float center_X = (i * tileLeng + (i+1)*tileLeng) / 2;
				float center_Z = (j * tileLeng + (j+1)*tileLeng) / 2;
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
		ref Vector3 centerPt, ref TerrainTile tt){
		tt.centroid = centerPt;
		switch(planet.planetType){
			case (int)PlanetType.Carbon:
				break;
			case (int)PlanetType.Iron:
				//Iron
				if(perlinVal > 0.7f){
					tt.iron = 1;
					return 1;
				}
				break;
			default:
				break;
		}
		return 0;
	}

}