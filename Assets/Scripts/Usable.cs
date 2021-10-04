using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usable : MonoBehaviour {

    public virtual bool Use() {
        Debug.Log("Usable used!");
        return false;
    }

    public virtual bool UseWith(Collectible other) {
        Debug.Log("Usable used with " + other.name);
        return false;
    }
}
