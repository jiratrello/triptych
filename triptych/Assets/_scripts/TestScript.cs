using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

	public Material mat;

	private Renderer rend;

	// Use this for initialization
	void Start () {

		rend = GetComponent<Renderer> ();
		rend.material = mat;

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
