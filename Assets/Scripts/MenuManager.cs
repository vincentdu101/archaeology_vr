﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

	public enum TYPE {START};
	private GameObject startMenu;
	private GameObject characterMenu;

	// Use this for initialization
	void Start () {
		startMenu = GameObject.Find("StartMenu");
		characterMenu = GameObject.Find("CharacterMenu");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Vector3 GetMenuPosition(TYPE menu) {
		if (menu == TYPE.START) {
			return startMenu.transform.position;
		}
		return startMenu.transform.position;
	}
}
