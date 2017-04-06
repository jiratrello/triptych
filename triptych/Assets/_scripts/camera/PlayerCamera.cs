using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

	public float lookSensitivity = 5f;
	public float xRotation;
	public float yRotation;

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

		if (Input.GetKeyDown("space")){ // if right button pressed...
			print("right button presssed");
			Cursor.visible = false;

			xRotation -= Input.GetAxis ("Mouse Y") * lookSensitivity;
			yRotation += Input.GetAxis ("Mouse X") * lookSensitivity;

			transform.rotation = Quaternion.Euler (xRotation, yRotation, 0);
		} else if (Input.GetKeyUp ("space")) {
			Cursor.visible = true;
		}
	}

	void SetCamVars () {
		mySky.material = camVars.sky;

		myCam.fieldOfView = camVars.fov;

	}
}
