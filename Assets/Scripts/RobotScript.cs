using UnityEngine;
using System.Collections;

public class Robot : Buyable{
	public int type;
	public int level;
	public Terrain terrain;
	public Resource cost; // TODO: change it to resources
	public Resource operationCost;

	public static int upperLimit = int.MaxValue;
	void Start () {
	
	}
	
	void Update () {
	
	}
}
