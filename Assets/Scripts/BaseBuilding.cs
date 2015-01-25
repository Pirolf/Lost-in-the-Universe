using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Reflection;
using System;

public class BaseBuilding : Building {
	public override void Awake(){
		upperLimit = 1;
	}

	void Start(){
		SetCost();
		type = (int)BuildingType.Base;
		buildingName = "Base";
		
	}	
	
	void Update () {
	}

	void SetCost(){
		cost = gameObject.AddComponent("Resource") as Resource;
		//cost.univen = 1000.0f;
	}
	public override void ShowInfo(){
		Debug.Log("Im a base");
	}

}
