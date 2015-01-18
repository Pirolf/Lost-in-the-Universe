using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ToggleConstructCallbacks : MonoBehaviour {
	public static Buyable itemToCheckOut;
	public BuildingManager buildingManager;
	public static Toggle selectedButton;
	void Start () {

	}

	public void OnToggle_ButtonConstruct(Buyable newSelectedItem){
		Toggle newBoundToggle = newSelectedItem.toggleButton;
		Debug.Log(newBoundToggle.name + " is on: " + newBoundToggle.isOn);
		//if this is just uncheck
		if(newBoundToggle.isOn == false){
			itemToCheckOut = null;
			return;
		}
		//uncheck old item
		if(itemToCheckOut != null){
			itemToCheckOut.toggleButton.isOn = false;
		}
		itemToCheckOut = newSelectedItem;
		//Debug.Log("new selected button: " + newBoundToggle.name);
		if(itemToCheckOut is Building){
			buildingManager.CreateBuilding((Building)itemToCheckOut);
		}else if (itemToCheckOut is Robot){
			//robotManager.CreateRobot((Robot)itemToCheckout);
		}
	}
	public void TestBuildingClick(){
		Debug.Log("building clicked");
	}
}
