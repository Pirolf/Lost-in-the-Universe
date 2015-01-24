using UnityEngine;
using System.Collections;

public class Building : Buyable {
	public string buildingName;
	public int type;
	public int id; 
	
	public override void Awake(){
		base.Awake();
		//Debug.Log("this is a building");
	}

	void Start () {
		//base.Start();
		Debug.Log("this is a building start");
	}
	
	void Update () {

	}
	void OnMouseDown(){
		ShowInfo();
	}
	public void PauseGame(){

	}
	public void ResumeGame(){
		
	}
	public virtual void CreateSelf(Vector3 spawnPosition){}
}







