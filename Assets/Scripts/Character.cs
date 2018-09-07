using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	private GameDataModel.CharacterChoice activeChoice;
	private CharacterDataService characterDataService;
	private MenuManager menuManager;
	private string characterName;

	// Use this for initialization
	void Start () {
		characterDataService = GameObject.Find("CharacterDataService").GetComponent<CharacterDataService>();
		menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void DetermineNewChoice() {
		GameDataModel.CharacterChoice choice = characterDataService.GetRandomChoice();
		Debug.Log(choice);
	}

	private void SetCharacterName() {
		if (characterName == null) {
			characterName = characterDataService.GetCharacterName();
		}
	}

	public void PlayerStartContact() {
		DetermineNewChoice();
		SetCharacterName();
		menuManager.MoveMenuToPlayer();
	}
}
