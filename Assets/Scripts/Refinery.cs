﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Refinery : Building {
	public GameObject actionPanel;
	private UIRef uiRef;

	public List<MiningRobot> miningRobots;
	public override void Awake(){
		base.Awake();
		uiRef = UIRef.myUIRef;
		miningRobots = new List<MiningRobot>();
	}

	void Start () {
		//base.Start();
		SetCost();
		type = (int)BuildingType.Refinery;
		buildingName = "Refinery";
	}
	
	void Update () {
	
	}
	//TODO
	void SetCost(){

	}
	public override void ShowInfo(){
		//enable entity action canvas
		uiRef.entityActionCanvas.SetActive(true);
		actionPanel.SetActive(true);
		//pause game
		PlayerScript.player.PauseGame();
	}
	public override void CreateSelf(Vector3 spawnPosition){
		Collider[] hitColliders = Physics.OverlapSphere(spawnPosition, 5.0f );
		//not the best way to do collision detection
		if (hitColliders.Length > 0) {
		    //return;
		    if(hitColliders.Length > 1){
		    	Debug.Log("ouch ouch");
		    	return;
		    }
		    if(hitColliders[0].gameObject == Terrain.activeTerrain){
		    	Debug.Log("i ONLY hit terrain");
		    }
		}
		BuildingManager bm = BuildingManager.myBuildingManager;
		Refinery rf
			= Instantiate(bm.refineryPrefab, spawnPosition, bm.refineryPrefab.transform.rotation)
			as Refinery;
		BuildingManager.Refinery_All.Add(rf);
		rf.gameObject.SetActive(true);
		//is this necessary at all?
		rf.transform.parent = bm.currentTerrain.transform;
		rf.Show(true);
	}
}
