using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Buyable : MonoBehaviour {
	public GameObject player;
	public Terrain terrain; // on which terrain

	public Toggle toggleButton; //toggle button bound to this buyable

	public Resource cost; 
	public Resource operationCost;
	public float currentWorth;// current worth in univen if it is sold right now


	public static int upperLimit = int.MaxValue; //per planet
	public static int globalUpperLimit = int.MaxValue; //in total

	public virtual void Awake(){
		cost = gameObject.AddComponent("Resource") as Resource;
		operationCost = gameObject.AddComponent("Resource") as Resource;
		Show(false);
	}
	void Start () {
		player = GameObject.Find("First Person Controller");
		terrain = Terrain.activeTerrain;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//disable a buyable's and its children renderers when first added
	public void Show(bool rendererOn = true){
		MeshRenderer mr = this.GetComponent<MeshRenderer>();
		if(mr != null)mr.enabled = rendererOn;
		Debug.Log(this.name);
		foreach (Transform childTransform in transform){
			mr = childTransform.gameObject.GetComponent<MeshRenderer>();
			if(mr != null)mr.enabled = rendererOn;
		}
	}

	public virtual void ShowInfo(){}
}
