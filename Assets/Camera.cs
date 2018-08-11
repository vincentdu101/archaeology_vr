using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	private GameObject camera;

	// Use this for initialization
	void Start () {
		camera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Vector3 GetCameraPosition() {
		return camera.transform.position;
	}

	public void SetCameraPosition(Vector3 position) {
		camera.transform.position = position;
	}
}
