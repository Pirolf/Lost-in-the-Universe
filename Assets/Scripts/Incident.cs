using UnityEngine;
using System.Collections;

public class Incident : MonoBehaviour {
	private static float lastAsteroidDetected = 0.0f;
	private static float minAsteroidInterval = 17 * 3600.0f;
	private static float maxAsteroidInterval = 40 * 3600.0f;
	private static float nextAsteroidInterval = Mathf.Infinity;
	private static float explosionBuffer = Mathf.Infinity;
	private static float minExplosionBuffer = 8.0f;
	private static float maxExplosionBuffer = 25.0f;

	//move this to a new script: natural and supernatural disasters
	void ScheduleAsteroid(){
		//every time when an asteroid is detected, generate an interval
		//for the next occurance of an asteroid
		if(explosionBuffer > 0){
			explosionBuffer -= Time.deltaTime;
		}
		if(explosionBuffer <= 0){
			//TODO: explode: pick a random location and explode
			//locations with buildings have much higher probability
			//80 : 20
			if(Random.value < 0.8){
				//blow building
			}else{
				//other random locations
			}
		}
		if(Mathf.Approximately(lastAsteroidDetected, nextAsteroidInterval)){
			nextAsteroidInterval = Random.Range(minAsteroidInterval, maxAsteroidInterval);
			//asteroid hit time: in 8 - 25 seconds
			explosionBuffer = Random.Range(minExplosionBuffer, maxExplosionBuffer);

		}else{
			lastAsteroidDetected += Time.deltaTime;
		}
	}
	// Use this for initialization
	void Start () {
		nextAsteroidInterval = Random.Range(minAsteroidInterval, maxAsteroidInterval);
	}
	
	// Update is called once per frame
	void Update () {
		if(SharedVariables.GamePaused)return;
		ScheduleAsteroid();
	}
}
