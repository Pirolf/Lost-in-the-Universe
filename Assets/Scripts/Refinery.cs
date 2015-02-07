using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Refinery : Building {
	public GameObject actionPanel;
	private UIRef uiRef;

	public List<MiningRobot> miningRobots;

	private int _tileIdx_x;
	private int _tileIdx_z;

	public int tileIdx_x{
		get{return _tileIdx_x;}
	}
	public int tileIdx_z{
		get{return _tileIdx_z;}
	}
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
		MapTile();
		rf.Show(true);
	}
	public void MapTile(){
		_tileIdx_x = Mathf.FloorToInt(gameObject.transform.position.x / TerrainScript.tileLeng);
 		_tileIdx_z = Mathf.FloorToInt(gameObject.transform.position.z / TerrainScript.tileLeng);
	}
}
