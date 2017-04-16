using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : MonoBehaviour {

    public new Camera camera;
    protected string avatarName;
    protected Item itemOnHand;
    protected Item[] itemOwn;
    protected int itemNum;
    protected Controller controller;
    protected int mode;
    protected const float velocity = 1.0f;
    protected const float MAX_V = 3.0f;
    protected const float MIN_V = 1.0f;
    protected const float INTERACT_DIS = 3.0f;

	// Use this for initialization
	void Start () {
        mode = 0;
        itemOnHand = null;
        itemOwn = new Item[4];
        itemNum = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setController(Controller ctrl) {
        controller = ctrl;
        controller.setAvatar(this);
        controller.activate ();
    }
    public Vector3 getLookDirection() {
        return camera.transform.forward;
    }
    public void move(Vector2 v) {
        if (v.magnitude > MAX_V) {
            v = v.normalized * MAX_V;
        }
        if (v.magnitude < MIN_V) {
            v = Vector2.zero;
        }
        gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (v.x, 0, v.y);
    }
    public void turn(Vector3 direction) {
    }
    public void selectItem(int itemIdx) {
        if (itemIdx == -1) {                    // use hand
            itemOnHand = null;
        }
        else {
            itemOnHand = itemOwn [itemIdx];
        }
    }
    public void interact() {
        GameObject inSight = getInSight ();
        if (!inSight)
            return;
        if (inSight.GetComponent<Item> ()) {
            Item item = inSight.GetComponent<Item> ();
            pick (item);
        }
        else if (inSight.GetComponent<Machine> ()) {
            Machine machine = inSight.GetComponent<Machine> ();
            if (itemOnHand) {
                useItemOnHand (machine);
            }
            else {
                machine.activate (null);
            }
        }
    }
    protected GameObject getInSight() {
        RaycastHit hit;
        if (Physics.Raycast (transform.position, camera.transform.forward, out hit, INTERACT_DIS)) {
            Debug.Log (hit.transform.gameObject.name);
            return hit.transform.gameObject;
        }
        else {
            return null;
        }
    }
    protected void pick(Item item) {
        itemOwn [itemNum] = item;
        itemNum++;
    }
    protected void useItemOnHand(Machine machine) {
        itemOnHand.usedOn (machine);
    }
}
