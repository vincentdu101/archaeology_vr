using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	private GameDataModel.CharacterChoice activeChoice;
	private CharacterDataService characterDataService;

	// Use this for initialization
	void Start () {
		characterDataService = GameObject.Find("CharacterDataService").GetComponent<CharacterDataService>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void DetermineNewChoice() {
		GameDataModel.CharacterChoice choice = characterDataService.GetRandomChoice();
		Debug.Log(choice);
	}

	public void PlayerStartContact() {
		DetermineNewChoice();
	}
}
