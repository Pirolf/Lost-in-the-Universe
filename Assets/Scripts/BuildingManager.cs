using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingManager : MonoBehaviour {
	[HideInInspector]public static BuildingManager myBuildingManager;
	//list or hashmap of buildings?
	[HideInInspector]public static List<UnknownMatterDetector> UMD_All;
	[HideInInspector]public static List<Refinery> Refinery_All;
	[HideInInspector]public static Building currentSelectedBuilding;
	//prefabs
	public BaseBuilding baseBuildingPrefab;
	public Refinery refineryPrefab;
	public UnknownMatterDetector detectorPrefab;

	public GameObject player;
	public TerrainScript currentTerrain;
	public PlayerScript playerScript;

	void Awake(){
		 UMD_All = new List<UnknownMatterDetector>();
		 Refinery_All = new List<Refinery>();
	}
	void Start () {
		myBuildingManager = this;
		currentTerrain = Terrain.activeTerrain.GetComponent<TerrainScript>();
		playerScript = player.GetComponent<PlayerScript>();
	}
	public void OnClickDestroy(){
		Object.Destroy(currentSelectedBuilding.gameObject);
	}
	public void CreateBuilding(Building building){
		//TODO: put a warning or something if there is no rayhitpt yet
		if(!playerScript.hasRayHitPt){
			Debug.Log("no ray hit");
			return;
		}
		if(building is BaseBuilding){
			BaseBuilding baseBuilding
				= Instantiate(baseBuildingPrefab, playerScript.rayHitPt, Quaternion.identity)
				as BaseBuilding;
			//attach to the terrain as child
			baseBuilding.gameObject.SetActive(true);
			baseBuilding.transform.parent = currentTerrain.transform;
			baseBuilding.Show(true);
			Debug.Log("new base buildling at :" + baseBuilding.transform.position);
		}else if(building is Refinery){
			building.CreateSelf(playerScript.rayHitPt);
			Debug.Log("Refinery created");
		}else if(building is UnknownMatterDetector){
			if(!ResourceManager.resourceManager.Affordable(ref building.cost)){
				Debug.Log("you are too poor");
				return;
			}
			ResourceManager.resourceManager.MinusResource(ref building.cost);
			building.CreateSelf(playerScript.rayHitPt);


		}
	}
	void Update () {
	
	}

}
