using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private GameState gameState;
	private MenuManager menuManager;
	private PlayerCamera playerCamera;
	private GameObject startingPoint;
	private float zBufferFromStartMenu = -0.4f;
	private float yBufferFromStartMenu = 22.9f;

    // Use this for initialization
    void Start () {
		gameState = GameObject.Find("GameState").GetComponent<GameState>();
		menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
		playerCamera = GameObject.Find("PlayerCamera").GetComponent<PlayerCamera>();
		startingPoint = GameObject.Find("StartingPoint");
		MovePlayerToStartMenu();
	}
	 
	// Update is called once per frame
	void Update () {
		
	}

	private void MovePlayerToStartMenu() {
		Vector3 menuPosition = menuManager.GetMenuPosition(MenuManager.TYPE.START);
		menuPosition.z += zBufferFromStartMenu;
		menuPosition.y += yBufferFromStartMenu;
		playerCamera.SetCameraPosition(menuPosition);
	}

	private void MovePlayerToStartPoint() {
		Vector3 initialPos = startingPoint.transform.position;
		playerCamera.SetCameraPosition(initialPos);
	}

	public void StartGame() {
		gameState.StartGame();
		MovePlayerToStartPoint();
	}
}
