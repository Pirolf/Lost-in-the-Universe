using UnityEngine;
using System.Collections;

public class BuildingManager : MonoBehaviour {
	//prefabs
	public GameObject player;
	public BaseBuilding baseBuildingPrefab;
	public TerrainScript currentTerrain;
	
	void Start () {
		currentTerrain = Terrain.activeTerrain.GetComponent<TerrainScript>();
	}
	
	void Update () {
	
	}

	public void CreateBuilding(Building building){
		if(building is BaseBuilding){
			currentTerrain.baseBuilding
			 = Instantiate(baseBuildingPrefab, player.GetComponent<PlayerScript>().rayHitPt, Quaternion.identity)
			 as BaseBuilding;
			 currentTerrain.baseBuilding.GetComponent<MeshRenderer>().enabled = true;
			 Debug.Log("new base buildling at :" + currentTerrain.baseBuilding.transform.position);
		}
		
	}

}
