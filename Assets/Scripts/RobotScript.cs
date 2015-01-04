using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {
	public int type;
	public int level;
	public Terrain terrain;
	public Cost cost; // TODO: change it to resources
	public Cost operationCost;
	
	public static int upperLimit = int.MaxValue;
	void Start () {
	
	}
	
	void Update () {
	
	}
}
