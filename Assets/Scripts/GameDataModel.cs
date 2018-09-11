using UnityEngine;
using System.Collections;

public class GameDataModel : MonoBehaviour {

	public enum ChoiceType {
		NORMAL, CLOSE
	}

	[System.Serializable]
	public class GameData {
		public string[] names;
		public CharacterChoice[] choices;
	}

	[System.Serializable]
	public class CharacterChoice {
		public string id;
		public string text;
		public Choice[] choices;
		public string resetChoice;
		public void clone(CharacterChoice choice) {
			this.id = choice.id;
			this.text = choice.text;
			this.choices = choice.choices;
			this.resetChoice = choice.resetChoice;
		}
	}

	[System.Serializable]
	public class Choice {
		private ChoiceType choiceType;
		private string text;
		private string sequence;
	}

}

