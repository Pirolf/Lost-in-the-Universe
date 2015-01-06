using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BaseBuilding : Building {
	public static int upperLimit = 1;
	void Start(){
		SetCost();
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
}
