using UnityEngine;
using System.Collections;

public class UnknownMatterDetector : Building {
	public GameObject actionPanel;

	private static float lastAsteroidDetected = 0.0f;
	private static float minAsteroidInterval = 17 * 3600.0f;
	private static float maxAsteroidInterval = 40 * 3600.0f;
	private static float nextAsteroidInterval = Mathf.Infinity;
	private static float explosionBuffer = Mathf.Infinity;
	private static float minExplosionBuffer = 8.0f;
	private static float maxExplosionBuffer = 25.0f;
	private UIRef uiRef;
	public override void Awake(){
		base.Awake();
		uiRef = UIRef.myUIRef;
	}
	// Use this for initialization
	void Start () {
		nextAsteroidInterval = Random.Range(minAsteroidInterval, maxAsteroidInterval);
	}
	
	// Update is called once per frame
	
	void Update () {



	}
	void OnDestroy(){
		//if this is the last detector
		if(BuildingManager.UMD_All.Count == 1){

		}
		//unregister from list
		BuildingManager.UMD_All.Remove(this);
		Debug.Log("removed detector");

	}
	//move this to a new script: natural and supernatural disasters
	void DetectAsteroid(){
		//every time when an asteroid is detected, generate an interval
		//for the next occurance of an asteroid
		if(explosionBuffer > 0){
			explosionBuffer -= Time.deltaTime;
		}
		if(explosionBuffer <= 0){
			//TODO: explode: pick a random location and explode
			//locations with buildings have much higher probability
			//80 : 20
			if(Random.value < 0.8){
				//blow building
			}else{
				//other random locations
			}
		}
		if(Mathf.Approximately(lastAsteroidDetected, nextAsteroidInterval)){
			nextAsteroidInterval = Random.Range(minAsteroidInterval, maxAsteroidInterval);
			//asteroid hit time: in 8 - 25 seconds
			explosionBuffer = Random.Range(minExplosionBuffer, maxExplosionBuffer);

		}else{
			lastAsteroidDetected += Time.deltaTime;
		}
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
			= Instantiate(bm.detectorPrefab, spawnPosition, Quaternion.identity)
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
