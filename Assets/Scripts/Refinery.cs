using UnityEngine;
using System.Collections;

public class Refinery : Building {
	// Use this for initialization
	void Start () {
		SetCost();
		type = (int)BuildingType.Refinery;
		buildingName = "Refinery";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//TODO
	void SetCost(){

	}
}
