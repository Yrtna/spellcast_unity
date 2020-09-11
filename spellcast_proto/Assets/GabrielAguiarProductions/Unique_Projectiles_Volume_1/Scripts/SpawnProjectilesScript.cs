using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnProjectilesScript : MonoBehaviour {

	public bool cameraShake;
	public Text effectName;
	public RotateToMouseScript rotateToMouse;
	public GameObject firePoint;
	public GameObject cameras;
	public List<GameObject> VFXs = new List<GameObject> ();

	private int count = 0;
	private float timeToFire = 0f;
	private GameObject effectToSpawn;
	private List<Camera> camerasList = new List<Camera> ();

	void Start () {
		
		for (int i = 0; i < cameras.transform.childCount; i++) {
			camerasList.Add (cameras.transform.GetChild(i).gameObject.GetComponent<Camera>());
		}

		Application.targetFrameRate = 60;
		effectToSpawn = VFXs[0];
		if (effectName != null) effectName.text = effectToSpawn.name;

		rotateToMouse.SetCamera (camerasList [2]);
		rotateToMouse.StartUpdateRay ();
	}

	void Update () {
		if (Input.GetKey (KeyCode.Space) && Time.time >= timeToFire || Input.GetMouseButton (0) && Time.time >= timeToFire) {
			timeToFire = Time.time + 1f / effectToSpawn.GetComponent<ProjectileMoveScript>().fireRate;
			SpawnVFX ();	
		}

		if (Input.GetKeyDown (KeyCode.D))
			Next ();
		if (Input.GetKeyDown (KeyCode.A)) 
			Previous ();	
		if (Input.GetKeyDown (KeyCode.C))
			SwitchCamera ();	
		if (Input.GetKeyDown (KeyCode.Alpha1))
			CameraShake ();
		if (Input.GetKeyDown (KeyCode.X))
			ZoomIn ();
		if (Input.GetKeyDown (KeyCode.Z))
			ZoomOut ();
	}

	public void SpawnVFX () {
		GameObject vfx;

		if (cameraShake && cameras != null)
			cameras.GetComponent<CameraShakeSimpleScript> ().ShakeCamera ();

		if (firePoint != null) {
			vfx = Instantiate (effectToSpawn, firePoint.transform.position, Quaternion.identity);
			if(rotateToMouse != null){
				vfx.transform.localRotation = rotateToMouse.GetRotation ();
			} 
			else Debug.Log ("No RotateToMouseScript found on firePoint.");
		}
		else
			vfx = Instantiate (effectToSpawn);

		var ps = vfx.GetComponent<ParticleSystem> ();

		if (vfx.transform.childCount > 0) {
			ps = vfx.transform.GetChild (0).GetComponent<ParticleSystem> ();
		}
	}

	public void Next () {
		count++;

		if (count > VFXs.Count)
			count = 0;

		for(int i = 0; i < VFXs.Count; i++){
			if (count == i)	effectToSpawn = VFXs [i];
			if (effectName != null)	effectName.text = effectToSpawn.name;
		}
	}

	public void Previous () {
		count--;

		if (count < 0)
			count = VFXs.Count;

		for (int i = 0; i < VFXs.Count; i++) {
			if (count == i) effectToSpawn = VFXs [i];
			if (effectName != null)	effectName.text = effectToSpawn.name;
		}
	}

	public void CameraShake () {
		cameraShake = !cameraShake;
	}

	public void ZoomIn () {
		for (int i = 0; i < camerasList.Count; i++) {
			camerasList [i].fieldOfView += 5;
		}
	}

	public void ZoomOut () {
		for (int i = 0; i < camerasList.Count; i++) {
			camerasList [i].fieldOfView -= 5;
		}
	}

	public void SwitchCamera () {
		for (int i = 0; i < camerasList.Count; i++) {
			if (camerasList [i].gameObject.activeSelf) {
				camerasList [i].gameObject.SetActive (false);
				if ((i+1) == camerasList.Count) {
					camerasList [0].gameObject.SetActive (true);
					rotateToMouse.SetCamera(camerasList [0]);
					break;
				} else {
					camerasList [i+1].gameObject.SetActive (true);
					rotateToMouse.SetCamera(camerasList [i+1]);
					break;
				}
			}
		}
	}
}
