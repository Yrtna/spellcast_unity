using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouseScript : MonoBehaviour {

	public float maximumLenght;

	private Ray rayMouse;
	private Vector3 pos;
	private Vector3 direction;
	private Quaternion rotation;
	private Camera cam;
	private WaitForSeconds updateTime = new WaitForSeconds (0.01f); 

	public void StartUpdateRay (){
		StartCoroutine (UpdateRay());
	}

	IEnumerator UpdateRay (){
		if (cam != null) {
			RaycastHit hit;
			var mousePos = Input.mousePosition;
			rayMouse = cam.ScreenPointToRay (mousePos);
			if (Physics.Raycast (rayMouse.origin, rayMouse.direction, out hit, maximumLenght)) {
				RotateToMouse (gameObject, hit.point);
			} else {	
				var pos = rayMouse.GetPoint (maximumLenght);
				RotateToMouse (gameObject, pos);
			}
			yield return updateTime;
			StartCoroutine (UpdateRay ());
		} else {
			Debug.Log ("Camera not set");
		}
	}

	void RotateToMouse (GameObject obj, Vector3 destination ) {
		direction = destination - obj.transform.position;
		rotation = Quaternion.LookRotation (direction);
		obj.transform.localRotation = Quaternion.Lerp (obj.transform.rotation, rotation, 1);
	}

	public void SetCamera (Camera camera){
		cam = camera;
	}

	public Vector3 GetDirection () {
		return direction;
	}

	public Quaternion GetRotation () {
		return rotation;
	}
}
