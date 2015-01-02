using UnityEngine;
using System.Collections;
[RequireComponent (typeof (CharacterController))]

public class PlayerScript : MonoBehaviour {
	public Vector3 velMagModifier;
	private CharacterController cc;
 	public GameObject selectedArea; 
 	//UI
 	public GameObject inGameMenu;
 	public GameObject inGameMenuPanel;

	private Vector3 rayHitPt;
	private Camera firstPersonCam;
	private bool scanPressed = false;
	private bool markedBuildArea = false;
	private bool inGameMenuActive = false;
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
        	//if selected a building

        	//Toggle building = toggleConstructCallbacks.selectedButton;
        	//if(building != null){
        		//TODO: place a building on mouse left click
        	//Vector3 buildingPos = selectedAreaProj.transform.position;
        	return;
        }else{
        	//slide out
       		inGameMenuCanvas.enabled = false;
        	inGameMenuPanelAnim.Play("InGameMenuSlideOut");
        	mouseLook.enabled = true;
        	Time.timeScale = 1;
        }

		if(scanPressed){
			selectedAreaProj.enabled = true;
			RaycastScan();
			MapTile();
		}else{
			selectedAreaProj.enabled = false;
		}
	}

	void RaycastScan() {
		RaycastHit hit;

		Ray rayPos = firstPersonCam.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(rayPos, out hit, Mathf.Infinity ) ) {
			GameObject hitObj = hit.collider.gameObject;
			Debug.Log(hit.point);

			selectedAreaProj.transform.position = hit.point + new Vector3(0,10,0);
			
			rayHitPt = hit.point;
		}
 	}

 	//find matching tile of the terrain and reveal resource info
 	void MapTile(){

 	}
}
