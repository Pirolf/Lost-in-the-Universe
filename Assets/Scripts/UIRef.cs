using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIRef : MonoBehaviour {
	[HideInInspector]public static UIRef myUIRef;

	public GameObject inGameMenu;
	public GameObject entityActionCanvas;

	//Resources
	public GameObject galacticaYen;


	public GameObject inGameMenuPanel;

	void Awake(){
		myUIRef = this;
		inGameMenu.SetActive(false);
	}
	void Start () {
		
	}

	public bool hasGUIActive(){
		if(inGameMenu.activeSelf)return true;
		if(entityActionCanvas.activeSelf)return true;
		return false;
	}
	public void QuitAllGUI(){
		if(inGameMenu.activeSelf){
			inGameMenuPanel.GetComponent<Animator>().Play("InGameMenuSlideOut");
			inGameMenu.SetActive(false);
			//return;
		}

		if(entityActionCanvas.activeSelf){
			entityActionCanvas.SetActive(false);
		}
	}


}
