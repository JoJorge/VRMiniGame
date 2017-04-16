using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBoardController : Controller {

    protected bool clicked;
    protected float clickTime;
    protected const float doubleClickPeriod = 0.3f;

	// Use this for initialization
	override public void Start () {
        base.Start ();
        clicked = false;
        GvrViewer.Create ();
	}
	
	// Update is called once per frame
    override public void Update () {
        if (!activative)
            return;
        
        // turn: automatically done by GvrViewer
        // move
        Vector3 camUp = GvrViewer.Instance.HeadPose.Orientation * Vector3.up;
        avatar.move (new Vector2(camUp.x * 8, camUp.z * 8));

        // click & double click
        if (GvrViewer.Instance.VRModeEnabled && GvrViewer.Instance.Triggered) {
            if (!clicked) {
                clickTime = Time.time;
                clicked = true;
            }
            else {                              // double click
                clicked = false;
                List<Item> items = avatar.getItemOwn();
                Item itOnHand = avatar.getItemOnHand ();
                if (items.Count != 0) {
                    if (itOnHand == null) {
                        avatar.selectItem (0);
                    }
                    else {
                        int idx = -1;
                        for(int i = 0; i < items.Count; i++) {
                            if (itOnHand == items[i]) {
                                idx = i;
                                break;
                            }
                        }
                        if (idx == items.Count - 1)
                            avatar.selectItem (-1);
                        else
                            avatar.selectItem (idx + 1);
                    }
                    
                }
            }
        }
        if (clicked) {
            if (Time.time - clickTime > doubleClickPeriod) {
                clicked = false;
                avatar.interact();
            }
        }
            
	}
}
