using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private GameState gameState;
	private MenuManager menuManager;
	private Camera camera;
	private GameObject startingPoint;
	private float zBufferFromStartMenu = -102.9f;

	// Use this for initialization
	void Start () {
		gameState = GameObject.Find("GameState").GetComponent<GameState>();
		menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
		camera = GameObject.Find("Camera").GetComponent<Camera>();
		startingPoint = GameObject.Find("StartingPoint");
		MovePlayerToStartMenu();
	}
	 
	// Update is called once per frame
	void Update () {
		
	}

	private void MovePlayerToStartMenu() {
		Vector3 menuPosition = menuManager.GetMenuPosition(MenuManager.TYPE.START);
		menuPosition.z += zBufferFromStartMenu;
		camera.SetCameraPosition(menuPosition);
	}

	private void MovePlayerToStartPoint() {
		Vector3 initialPos = startingPoint.transform.position;
		camera.SetCameraPosition(initialPos);
	}

	public void StartGame() {
		gameState.StartGame();
	}
}
