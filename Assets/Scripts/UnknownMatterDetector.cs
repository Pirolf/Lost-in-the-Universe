using UnityEngine;
using System.Collections;

public class UnknownMatterDetector : Building {
	public GameObject actionPanel;

	private UIRef uiRef;
	void Awake(){
		uiRef = UIRef.myUIRef;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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
		//Debug.Log("detector");
		BuildingManager bm = BuildingManager.myBuildingManager;
		UnknownMatterDetector detector
			= Instantiate(bm.detectorPrefab, spawnPosition, Quaternion.identity)
			as UnknownMatterDetector;
		detector.gameObject.SetActive(true);
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
}
