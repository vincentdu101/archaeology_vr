﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CharacterDataService : MonoBehaviour {

	private string gameDataFileName = "characters.json";
	private int stage = 1;
	private string sequence = "0";
	private Dictionary<string, GameDataModel.CharacterChoice> keyFigureProgress;
	public string[] names;
	public Dictionary<string, GameDataModel.CharacterChoice> previousChoices;
	public Dictionary<string, GameDataModel.CharacterChoice> choices;

	// Use this for initialization
	void Start () {
		choices = new Dictionary<string, GameDataModel.CharacterChoice> ();
		previousChoices = new Dictionary<string, GameDataModel.CharacterChoice> ();
		LoadDataFromFile ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void LoadChoicesIntoDictionary(GameDataModel.CharacterChoice[] inputChoices) {
		foreach (GameDataModel.CharacterChoice choice in inputChoices) {
			if (!choices.ContainsKey (choice.id)) {
				Debug.Log (choice.id);
				Debug.Log (choice);
				choices.Add (choice.id, choice);
			}
		}
	}

	private void LoadDataFromFile() {
		// Path.Combine combines strings into a file path
		// Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
		Debug.Log(Application.streamingAssetsPath);
		string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

		if(File.Exists(filePath)) {
			// Read the json from the file into a string
			string dataAsJson = File.ReadAllText(filePath); 
			
			// Pass the json to JsonUtility, and tell it to create a GameData object from it
			GameDataModel.GameData data = JsonUtility.FromJson<GameDataModel.GameData>(dataAsJson);

			// Retrieve the names and choices property of data
			Debug.Log("names " + data.names.ToString());
			names = data.names;
			LoadChoicesIntoDictionary (data.choices);
		} else {
			Debug.LogError("Cannot load game data!");
		}
	}

	public GameDataModel.CharacterChoice GetRandomChoice() {
		int randomChoice = Random.Range (0, 2);
		string key = "VC" + stage + "S" + randomChoice + "-" + sequence;
		GameDataModel.CharacterChoice character;
		choices.TryGetValue(key, out character);
		return character;
	}

	public void StartEricQuest(int path) {
		sequence += "A";
	}

	public string GetKeyFigureSequence(string figure) {
		switch (figure) {
		case "EricTheRed": {
			return "A";
		}
		case "Illugi": {
				return "A";
		}
		case "ShipCaptain": {
				return "A";
		}
		case "Glaumur": {
				return "A";
		}
		default:	
			return "0";
		}
	}

	public GameDataModel.CharacterChoice GetKeyFigureChoice(string figure) {
		GameDataModel.CharacterChoice previousChoice;
		GameDataModel.CharacterChoice nextChoice;
		string key; 
		previousChoices.TryGetValue(figure, out previousChoice);
		if (previousChoice == null) {
			key = "VC" + stage + "S0" + "-0" + GetKeyFigureSequence(figure);
		} else {
			key = previousChoice.resetChoice;
		}
		choices.TryGetValue(key, out nextChoice);
		previousChoices.Remove (figure);
		previousChoices.Add (figure, nextChoice);
		return nextChoice;
	}

	public string GetCharacterName() {
		foreach (string name in names) {
			Debug.Log (name);
		}
		int random = Random.Range (0, names.Length - 1);
		return names[random];
	}
}
