using UnityEngine;
using System.Collections;

public class Building : Buyable {
	public string buildingName;
	public int type;
	public int id; //do we need an id?
	public Terrain terrain; // on which terrain
	public Resource cost; //TODO: change it to resources
	public Resource operationCost;
	public static int upperLimit = int.MaxValue; //per planet
	public static int globalUpperLimit = int.MaxValue; //in total
	void Start () {
		
	}
	
	void Update () {
	
	}
}







