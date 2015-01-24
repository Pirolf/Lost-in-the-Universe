using UnityEngine;
using System.Collections;

public class Refinery : Building {
	public override void Awake(){
		base.Awake();
	}
	void Start () {
		//base.Start();
		SetCost();
		type = (int)BuildingType.Refinery;
		buildingName = "Refinery";
	}
	
	void Update () {
	
	}
	//TODO
	void SetCost(){

	}
	public override void CreateSelf(Vector3 spawnPosition){

	}
}
