using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBoardController : Controller {

	// Use this for initialization
	override public void Start () {
        base.Start ();
        GvrViewer.Create ();
	}
	
	// Update is called once per frame
    override public void Update () {
        if (activative) {
            Vector3 camUp = GvrViewer.Instance.HeadPose.Orientation * Vector3.up;
            avatar.move (new Vector2(camUp.x * 8, camUp.z * 8));
            if (GvrViewer.Instance.VRModeEnabled && GvrViewer.Instance.Triggered) {
                avatar.interact ();
            }
        }
	}
}
