using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    protected Avatar avatar;
    [SerializeField]
    protected bool activative;

	// Use this for initialization
	virtual public void Start () {
        activative = false;
	}
	
	// Update is called once per frame
	virtual public void Update () {
		
	}

    public void setAvatar(Avatar av) {
        avatar = av;
    }

    public void activate() {
        activative = true;
    }
    public void disactivate() {
        activative = false;
    }
}
