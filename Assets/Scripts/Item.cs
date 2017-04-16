using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public bool singleUse;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void usedOn(Machine machine, ref bool isDestroy) {
        if (machine.activate (this)) {
            if (singleUse) {
                isDestroy = true;
            }
            return;
        }
    }
}
