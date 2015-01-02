using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//[RequireComponent (typeof (Toggle))]


public class ToggleConstructCallbacks : MonoBehaviour {
	public static Toggle selectedButton;

	void Start () {

	}
	
	public void OnToggle_ButtonConstruct(Toggle newSelectedButton){
		Debug.Log(newSelectedButton.name + " is on: " + newSelectedButton.isOn);
		if(newSelectedButton.isOn == false){
			selectedButton = null;
			return;
		}
		if(selectedButton == null){
			selectedButton = newSelectedButton;
			return;
		}
		selectedButton.isOn = false;
		selectedButton = newSelectedButton;
		Debug.Log("new selected button: " + selectedButton.name);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
