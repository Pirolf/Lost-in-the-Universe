using UnityEngine;
using System.Collections;

public class UnknownMatterDetector : Building {
	public GameObject actionPanel;
	private static float pDetectAsteroid = 0.7f; // probability of detecting an asteriod
	
	private UIRef uiRef;
	public override void Awake(){
		base.Awake();
		uiRef = UIRef.myUIRef;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	
	void Update () {
		


	}
	void OnDestroy(){
		//if this is the last detector
		if(BuildingManager.UMD_All.Count == 1){

		}
		//unregister from list
		BuildingManager.UMD_All.Remove(this);
		//exit menu
		uiRef.entityActionCanvas.SetActive(false);

		PlayerScript.player.ResumeGame();
		Debug.Log("removed detector");

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
		UnknownMatterDetector detector
			= Instantiate(bm.detectorPrefab, spawnPosition, bm.detectorPrefab.transform.rotation)
			as UnknownMatterDetector;
		BuildingManager.UMD_All.Add(detector);
		detector.gameObject.SetActive(true);
		//is this necessary at all?
		detector.transform.parent = bm.currentTerrain.transform;
		detector.Show(true);
		
	}
	public override void ShowInfo(){
		//enable entity action canvas
		uiRef.entityActionCanvas.SetActive(true);
		actionPanel.SetActive(true);
		//pause game
		PlayerScript.player.PauseGame();
	}
	
	public void ResetCost(){
		cost.galacticaYen = 400.0f;
	}
}
