using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public enum TYPE {START};
	private GameObject startMenu;
	private GameObject characterMenu;
	private PlayerCamera player;
	private Vector3 menuCameraBuffer = new Vector3(0.0f, 1.0f, 1.0f);
	private int distance = 3;

	// Use this for initialization
	void Start () {
		startMenu = GameObject.Find("StartMenu");
		characterMenu = GameObject.Find("CharacterMenu");
		player = GameObject.Find("PlayerCamera").GetComponent<PlayerCamera>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void ModifyCharacterName(string name) {
		Text nameText = GameObject.Find("Name").GetComponent<Text>();
		nameText.text = name;
	}
	private void ModifyCharacterMessage(string dialogue) {
		Text messageText = GameObject.Find("Dialogue").GetComponent<Text>();
		messageText.text = dialogue;
	}

	private void LoadChoicesIntoMenu(GameDataModel.Choice[] choices) {
		foreach (GameDataModel.Choice choice in choices) {
			
		}
	}

	public Vector3 GetMenuPosition(TYPE menu) {
		if (startMenu != null && menu == TYPE.START) {
			return startMenu.transform.position;
		}
		return new Vector3(0, 0, 0);
	}

	public void MoveMenuToPlayer(GameObject menu) {
		Transform playerTransform = player.GetCameraTransform();
		menu.SetActive (true);
		menu.transform.position = playerTransform.position + menuCameraBuffer + playerTransform.forward * distance;
		menu.transform.rotation = new Quaternion (0.0f, playerTransform.rotation.y, 0.0f, playerTransform.rotation.w);
	}

	public void SetupCharacterMenu(GameDataModel.CharacterChoice choice, string name) {
		MoveMenuToPlayer(characterMenu);
		ModifyCharacterName(name);
		ModifyCharacterMessage(choice.text);
		LoadChoicesIntoMenu(choice.choices);
	}
}
