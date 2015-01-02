using UnityEngine;
using System.Collections;

public class Planet{
	public int planetType;
	//resources
	public int iron = 0;
	public int copper = 0;
	public int silicon = 0;
	//climate?
	public Planet(){
		planetType = (int)PlanetType.UNKNOWN;
	}
}
public class IronPlanet : Planet{
	public IronPlanet(){
		planetType = (int)PlanetType.Iron;
	}
}
