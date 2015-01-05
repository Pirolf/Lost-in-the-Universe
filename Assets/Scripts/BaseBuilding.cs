using UnityEngine;
using System.Collections;

public class BaseBuilding : Building {
	public GameObject prefab;
	public static int upperLimit = 1;
	void Start(){
		player = GameObject.Find("First Person Controller");
		Debug.Log(player.name);
		SetCost();
		terrain = Terrain.activeTerrain;
		type = (int)BuildingType.Base;
		buildingName = "Base";
	}	
	// Update is called once per frame
	void Update () {
	
	}

	void SetCost(){
		cost = gameObject.AddComponent("Resource") as Resource;
		cost.univen = 1000.0f;
	}
	public void InstantiateBase(){
		prefab = (GameObject)Instantiate(prefab, 
			player.GetComponent<PlayerScript>().rayHitPt, 
			Quaternion.identity) ;
	}
}
