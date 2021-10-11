using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetusController : MonoBehaviour {
    private void Start() {
        var rigidbody2D = GetComponent<Rigidbody2D>();

        rigidbody2D.angularDrag = 0;
        rigidbody2D.angularVelocity = 30;
    }
}
