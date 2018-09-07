using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

	private new GameObject camera;

	// Use this for initialization
	void Start () {
		camera = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Vector3 GetCameraPosition() {
		return camera.transform.position;
	}

	public Transform GetCameraTransform() {
		return camera.transform;
	}

	public void SetCameraPosition(Vector3 position) {
		if (camera != null) {
			camera.transform.position = position;
		}
	}
}
