using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public Avatar avatar;

	// Use this for initialization
	void Start () {
        Controller ctrl = GameObject.Find("CardBoardController").GetComponent<CardBoardController>();
        avatar.setController (ctrl);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
