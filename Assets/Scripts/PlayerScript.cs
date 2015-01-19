using UnityEngine;
using System.Collections;
[RequireComponent (typeof (CharacterController))]
//TODO: add a glider
public class PlayerScript : MonoBehaviour {

	public Vector3 velMagModifier;
	private CharacterController cc;
 	public GameObject selectedArea; 
 	//Resources
 	public Resource resource;
 	//UI
 	public GameObject inGameMenu;
 	public GameObject inGameMenuPanel;

	public Vector3 rayHitPt;
	private Camera firstPersonCam;
	private bool scanPressed = false;
	private bool inGameMenuPressed = false;
	private bool markedBuildArea = false;
	private bool inGameMenuActive = false;
	public bool hasRayHitPt = false;
	//components
	private Animator inGameMenuPanelAnim;
	private MouseLook mouseLook;
	private Projector selectedAreaProj;
	private Canvas inGameMenuCanvas;
	private ToggleConstructCallbacks toggleConstructCallbacks;

	void Start () {
		//get components
		cc = GetComponent<CharacterController>();
		selectedAreaProj = selectedArea.GetComponent<Projector>();
		inGameMenuPanelAnim = inGameMenuPanel.GetComponent<Animator>();
		mouseLook = gameObject.GetComponent<MouseLook>();
		inGameMenuCanvas = inGameMenu.GetComponent<Canvas>();
		toggleConstructCallbacks = gameObject.GetComponent<ToggleConstructCallbacks>();
		firstPersonCam = GameObject.Find("FirstPersonCamera").gameObject.camera;

		selectedAreaProj.GetComponent<Projector>().enabled = false;
		inGameMenu.GetComponent<Canvas>().enabled = false;
		inGameMenuPanelAnim.enabled = false;

		InitResource();
		Time.timeScale = 1;
	}
	
	void Update () {
		UpdateInput();
	}

	void UpdateInput(){
		if(Input.GetButtonDown("Scan")){
			scanPressed = !scanPressed;
		}
		if(Input.GetMouseButton(0)){
			//Debug.Log("Pressed left click.");
		}
		if(Input.GetButtonDown("InGameMenu")){
			inGameMenuActive = !inGameMenuActive;
			inGameMenuPressed = true;
		}else{
			inGameMenuPressed = false;
		}
           
        if(inGameMenuActive){
        	//slide in
        	inGameMenuCanvas.enabled = true;
        	inGameMenuPanelAnim.enabled = true;
        	inGameMenuPanelAnim.Play("InGameMenuSlideIn");
        	//freeze transformation
        	Time.timeScale = 0;
        	//no look around
        	mouseLook.enabled = false;
        	return;
        }else{
        	inGameMenuPanelAnim.Play("InGameMenuSlideOut");
        	if(inGameMenuPressed){
        		//reset all toggles to unchecked
        		
        	}
        	
        	mouseLook.enabled = true;
        	Time.timeScale = 1;
        }

		if(scanPressed){
			mouseLook.enabled = true;
			RaycastScan();
			selectedAreaProj.enabled = true;
			MapTile();
		}else{
			selectedAreaProj.enabled = false;
			hasRayHitPt = false;
			//if mouse position hits a building or a robot
			//show building infomation and bring up a activity menu
			RaycastSelectThing();
		}
	}
	void InitResource() {
		resource = gameObject.AddComponent("Resource") as Resource;
		resource.univen = 1500.0f;
		resource.iron = 200.0f;
		resource.copper = 100.0f;
		resource.wood =  500.0f;
	}

	//raycast mouse input position, if hits a building or a robot, show info
	void RaycastSelectThing(){
		RaycastHit hit;
		Ray rayPos = firstPersonCam.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(rayPos, out hit, Mathf.Infinity )) 
		{
			//if hits a building or a robot
			GameObject hitObj = hit.collider.gameObject;
			if(hitObj.tag.Equals("Buyable"))
			{
				Debug.Log("hit buyable");
				//hitObj.GetComponent<Buyable>().ShowInfo();
			}	
		}
		else
		{

		}
	}
	void RaycastScan() {
		RaycastHit hit;

		Ray rayPos = firstPersonCam.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(rayPos, out hit, Mathf.Infinity ) ) {
			GameObject hitObj = hit.collider.gameObject;
			//Debug.Log(hit.point);

			selectedAreaProj.transform.position = hit.point + new Vector3(0,10,0);
			
			rayHitPt = hit.point;
			hasRayHitPt = true;
		}else{
			hasRayHitPt = false;
		}
 	}

 	//find matching tile of the terrain and reveal resource info
 	void MapTile(){

 	}
}
