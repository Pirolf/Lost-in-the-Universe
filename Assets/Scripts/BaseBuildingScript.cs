using UnityEngine;
using System.Collections;

public class BaseBuildingScript : Building {

	public static int upperLimit = 1;
	void Start(){
		SetCost();
		terrain = Terrain.activeTerrain;
		type = (int)BuildingType.Base;
		buildingName = "Base";
	}	
	// Update is called once per frame
	void Update () {
	
	}

	void SetCost(){
		cost.univen = 1000.0f;
	}
}
