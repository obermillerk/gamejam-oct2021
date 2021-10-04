using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

    [SerializeField] private int uses = 1;
    private GameObject owner;
    
    public virtual void CollectedBy(GameObject other) {
        var body = GetComponent<Rigidbody2D>();
        body.mass = 0;
        body.angularDrag = 2;
        body.drag = 2;

        GetComponent<Collider2D>().enabled = false;
        
        var springJoint = gameObject.AddComponent<SpringJoint2D>();
        springJoint.connectedBody = other.GetComponent<Rigidbody2D>();
        springJoint.autoConfigureDistance = false;
        springJoint.distance = 10;
        springJoint.dampingRatio = 1f;
    }

    public virtual void Use() {
        Destroy(gameObject);
    }
}