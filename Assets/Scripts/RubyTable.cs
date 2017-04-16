using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyTable : Machine {

    public GameObject ruby;
    public GameObject wall;

    public override bool activate (Item item)
    {
        if (item != null && item.name == "Ruby") {
            ruby.SetActive (true);
            wall.SetActive (false);
            return true;
        }
        return false;
    }
}
