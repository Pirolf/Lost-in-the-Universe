using UnityEngine;
using System.Collections;

public class SharedVariables : MonoBehaviour {
	//game states
	public static bool GamePaused;
	void Awake(){
		GamePaused = false;
	}
	void Start () {
	
	}
	
}
