using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
[RequireComponent (typeof (CharacterController))]
//TODO: add a glider
public class PlayerScript : MonoBehaviour {
	[HideInInspector]public static PlayerScript player;
	private UIRef uiRef;
	public Vector3 velMagModifier;
	private CharacterController cc;
 	public GameObject selectedArea; 
 	//Resources
 	public Resource resource;

	public Vector3 rayHitPt;
	private Camera firstPersonCam;
	private bool scanPressed = false;
	private bool markedBuildArea = false;
	public bool hasRayHitPt = false;
	//components
	private MouseLook mouseLook;
	private Projector selectedAreaProj;
	private ToggleConstructCallbacks toggleConstructCallbacks;

	void Awake(){
		player = this;
		uiRef = UIRef.myUIRef;
	}
	void Start () {
		//get components
		cc = GetComponent<CharacterController>();
		selectedAreaProj = selectedArea.GetComponent<Projector>();
		mouseLook = gameObject.GetComponent<MouseLook>();
		toggleConstructCallbacks = gameObject.GetComponent<ToggleConstructCallbacks>();
		firstPersonCam = GameObject.Find("FirstPersonCamera").gameObject.camera;

		selectedAreaProj.GetComponent<Projector>().enabled = false;

		Time.timeScale = 1;
	}
	
	void Update () {
		UpdateInput();
	}

	void UpdateInput(){
		
		if(Input.GetButtonDown("ResumeGame")){
			//close all gui
			uiRef.QuitAllGUI();
			ResumeGame();
			return;
		}
		if(Input.GetButtonDown("InGameMenu")){
			Animator anim = uiRef.inGameMenuPanel.GetComponent<Animator>();
			if(uiRef.inGameMenu.activeSelf){
				anim.enabled = true;
				//anim.PlayQueued("InGameMenuSlideOut");
				//yield uiRef.WaitForAnimation(anim);
				//anim.Play("InGameMenuSlideOut");
				uiRef.inGameMenu.SetActive(false);
				//uncheck all toggles
				ToggleConstructCallbacks.myCallbacks.ClearSelected();
				ResumeGame();

				return;
			}else{
				uiRef.inGameMenu.SetActive(true);
				anim.Play("InGameMenuSlideIn");
				PauseGame();
				return;
			}
		}

		//check if any gui is active
		if(uiRef.hasGUIActive()){
			PauseGame();
			return;
		}
		if(Input.GetButtonDown("Scan")){
			scanPressed = !scanPressed;
		}

		if(scanPressed){
			mouseLook.enabled = true;
			RaycastScan();
			selectedAreaProj.enabled = true;
			MapTile();
		}else{
			selectedAreaProj.enabled = false;
			hasRayHitPt = false;
		}
	}
	public void PauseGame(){
		Time.timeScale = 0;
        mouseLook.enabled = false;
        SharedVariables.GamePaused = true;
	}
	public void ResumeGame(){
		mouseLook.enabled = true;
        Time.timeScale = 1;
        SharedVariables.GamePaused = false;
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
