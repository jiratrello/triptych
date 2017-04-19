using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

	//player controls
	public float lookSensitivity = 5f;
	public float xRotation;
	public float yRotation;
	public float zRotation;

	//camera properties
	CameraVariables camVars;
	Camera myCam;
	Skybox mySky;
	float myFov;
	LayerMask myMask;

	void Start () {

		myCam = GetComponent<Camera> ();

		mySky = GetComponent<Skybox> ();

	}

	void Update () {

		if (Input.GetMouseButtonDown(0)){ // if left button pressed...
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				if (hit.transform.tag == "ClickableObject")
					// the object identified by hit.transform was clicked
					camVars = hit.transform.GetComponent<CameraVariables> ();
				SetCamVars ();
			}
		}

		if (Input.GetMouseButton(1)){ // if right button pressed...
			print("right button presssed");
			Cursor.visible = false;

			xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
			yRotation += Input.GetAxis("Mouse X") * lookSensitivity;

			//transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

		} else if (Input.GetMouseButtonUp (1)) {
			Cursor.visible = true;
		}

		if (Input.GetMouseButton(2)) {
			zRotation -= Input.GetAxis ("Mouse ScrollWheel") * lookSensitivity;
			//transform.rotation = Quaternion.Euler (0, 0, zRotation);
		}

		transform.rotation = Quaternion.Euler (xRotation, yRotation, zRotation);
	}

	void SetCamVars () {
		transform.parent = camVars.parent.transform;
		//transform.localPosition = new Vector3(0, 0, 0);
		//DOESNT WORK LEARN 2 LERP
		transform.position = Vector3.Lerp(transform.position, camVars.parent.transform.position, 5);

		mySky.material = camVars.sky;
		myCam.fieldOfView = camVars.fov;
		myCam.cullingMask = LayerMask.GetMask(camVars.layers); //camVars.mask;
	}
}
