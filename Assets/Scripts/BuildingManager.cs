using UnityEngine;
using System.Collections;

public class BuildingManager : MonoBehaviour {
	[HideInInspector]public static BuildingManager myBuildingManager;
	//prefabs
	public BaseBuilding baseBuildingPrefab;
	public Refinery refineryPrefab;
	public UnknownMatterDetector detectorPrefab;

	public GameObject player;
	public TerrainScript currentTerrain;
	public PlayerScript playerScript;

	void Start () {
		myBuildingManager = this;
		currentTerrain = Terrain.activeTerrain.GetComponent<TerrainScript>();
		playerScript = player.GetComponent<PlayerScript>();
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
			
			Refinery refinery
				= Instantiate(refineryPrefab, playerScript.rayHitPt, refineryPrefab.transform.rotation)
				as Refinery;
			refinery.gameObject.SetActive(true);
			refinery.transform.parent = currentTerrain.transform;
			refinery.Show(true);
			
			//building.CreateSelf(playerScript.rayHitPt);
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
