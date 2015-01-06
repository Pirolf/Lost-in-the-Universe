using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Buyable : MonoBehaviour {
	public GameObject player;
	public Terrain terrain; // on which terrain
	public Toggle toggleButton; //toggle button bound to this buyable
	public Resource cost; 
	public Resource operationCost;
	public static int upperLimit = int.MaxValue; //per planet
	public static int globalUpperLimit = int.MaxValue; //in total

	void Awake(){
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
			//Debug.Log(childTransform.gameObject.name);
			mr = childTransform.gameObject.GetComponent<MeshRenderer>();
			if(mr != null)mr.enabled = rendererOn;
		}
	}
}
