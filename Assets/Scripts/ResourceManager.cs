using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceManager : MonoBehaviour {

	[HideInInspector]public static ResourceManager resourceManager;
	public Resource playerResource;


	void Awake(){
		resourceManager = this;
		//startup fund
		playerResource = GetComponent<Resource>();
		playerResource.galacticaYen = 5000.0f;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public bool Affordable(ref Resource cost){
		if(playerResource.galacticaYen < cost.galacticaYen)return false;
		return true;
	}
	public void MinusResource(ref Resource amount){
		float gYen = amount.galacticaYen;
		playerResource.galacticaYen -= gYen;
		//change display text
		UIRef.myUIRef.galacticaYen.GetComponent<Text>().text = playerResource.galacticaYen.ToString("0.0");
	}
}
