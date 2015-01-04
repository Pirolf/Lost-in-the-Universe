using UnityEngine;
using System.Collections;

public class MiningRobot : Robot {
	public static int upperLimit = 300;
	public Vector3 movingSpeed;
	public float miningRate = 1.0f;
	//Robot with specialty mines its specialty type faster
	public int specializeInType = (int)ResourceType.DEFAULT;
	public float miningRateMultiplier = 1.1f;

	void Start () {
		terrain = Terrain.activeTerrain;
		level = 0;
		type = (int)RobotType.Mining;
		movingSpeed = new Vector3(5.0f, 0.0f, 5.0f);
	}

	void Update () {

	}

	void SetCost(){
		cost.univen = 20.0f;
		operationCost.univen = 0.2f;
	}
}
