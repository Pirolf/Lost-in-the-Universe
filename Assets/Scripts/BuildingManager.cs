using UnityEngine;
using System.Collections;

public class BuildingManager : MonoBehaviour {
	//prefabs
	public GameObject player;
	public BaseBuilding baseBuildingPrefab;
	public Refinery refineryPrefab;
	public TerrainScript currentTerrain;
	public PlayerScript playerScript;

	void Start () {
		currentTerrain = Terrain.activeTerrain.GetComponent<TerrainScript>();
		playerScript = player.GetComponent<PlayerScript>();
	}
	
	void Update () {
	
	}

	public void CreateBuilding(Building building){
		//TODO: put a warning or something if there is no rayhitpt yet
		if(!playerScript.hasRayHitPt){
			Debug.Log("no ray hit, didn't create a building");
			return;
		}
		if(building is BaseBuilding){
			currentTerrain.baseBuilding
				= Instantiate(baseBuildingPrefab, playerScript.rayHitPt, Quaternion.identity)
				as BaseBuilding;
			currentTerrain.baseBuilding.Show(true);
			Debug.Log("new base buildling at :" + currentTerrain.baseBuilding.transform.position);
		}else if (building is Refinery){
			Refinery refinery
				= Instantiate(refineryPrefab, playerScript.rayHitPt, Quaternion.identity)
				as Refinery;
			currentTerrain.refineries.Add(refinery);
			refinery.Show(true);
			Debug.Log("Refinery created");
		}

		
	}

}
