using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeSimpleScript : MonoBehaviour {

	private bool isRunning = false;
	private Animation anim;

	void Start () {
		anim = GetComponent<Animation> ();
	}

	public void ShakeCamera() {	
		anim.Play(anim.clip.name);
	}

	//other shake option
	public void ShakeCaller (float amount, float duration){
		StartCoroutine (Shake(amount, duration));
	}

	IEnumerator Shake (float amount, float duration){
		isRunning = true;

		Vector3 originalPos = transform.localPosition;
		int counter = 0;

		while (duration > 0.01f) {
			counter++;

			var x = Random.Range (-1f, 1f) * (amount/counter);
			var y = Random.Range (-1f, 1f) * (amount/counter);

			transform.localPosition = new Vector3 (x, y, originalPos.z);

			duration -= Time.deltaTime;
			
			yield return new WaitForSeconds (0.1f);
		}

		transform.localPosition = originalPos;

		isRunning = false;
	}
}
