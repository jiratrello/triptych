using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

	Camera myCam;

	Skybox mySky;

	float myFov;

	CameraVariables camVars;

	void Start () {

		myCam = GetComponent<Camera> ();

		mySky = GetComponent<Skybox> ();

	}

	void Update () {

		if (Input.GetMouseButtonDown(0)){ // if left button pressed...
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				// the object identified by hit.transform was clicked
				camVars = hit.transform.GetComponent<CameraVariables> ();
				SetCamVars ();
			}
		}
	}

	void SetCamVars () {
		mySky.material = camVars.sky;

		myCam.fieldOfView = camVars.fov;

	}
}
