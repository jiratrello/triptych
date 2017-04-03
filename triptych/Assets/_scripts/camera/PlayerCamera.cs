using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

	Skybox mySky;

	CameraVariables camVars;

	// Use this for initialization
	void Start () {
		
		mySky = GetComponent<Skybox> ();

	}

	void Update () {

		if (Input.GetMouseButton(0)) {
			FirstFunction ();
		}

		if (Input.GetMouseButton(1)) {
			SecondFunction ();
		}

		if (Input.GetMouseButton(2)) {
			ThirdFunction ();
		}
	}

	void FirstFunction() {
		print ("this is the first function");
		GameObject obj = GameObject.Find ("OBJ1");
		camVars = obj.GetComponent<CameraVariables> ();
		SetCamVars();
	}

	void SecondFunction() {
		print ("this is the second function");
		GameObject obj = GameObject.Find ("OBJ2");
		camVars = obj.GetComponent<CameraVariables> ();
		SetCamVars();
	}

	void ThirdFunction() {
		print ("this is the third function");
		GameObject obj = GameObject.Find ("OBJ3");
		camVars = obj.GetComponent<CameraVariables> ();
		SetCamVars();
	}

	void SetCamVars () {
		mySky.material = camVars.sky;

	}
		
}
