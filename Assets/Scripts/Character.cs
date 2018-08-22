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
		characterDataService.GetRandomChoice();
	}

	public void PlayerStartContact() {
		DetermineNewChoice();
	}
}
