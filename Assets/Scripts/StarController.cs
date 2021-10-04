using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {
    void FixedUpdate() {
        var body = GetComponent<Rigidbody2D>();
        
        var particulate = GetComponentInChildren<ParticleSystem>();
        var particulateTransform = particulate.transform;

        var cam = Camera.main;

        Vector2 leftPoint = cam.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
        Vector2 rightPoint = cam.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));
        var diagLength = (leftPoint - rightPoint).magnitude;

        var radius = 0.6f * diagLength;

        var sh = particulate.shape;
        sh.radius = diagLength;
        
        var inFront = body.GetVector(body.velocity).normalized;
        if (inFront.sqrMagnitude == 0) inFront = new Vector2(0f, 1f);
        
        particulateTransform.localPosition = new Vector3(inFront.x * radius, inFront.y * radius, particulateTransform.position.z);
        particulateTransform.rotation = Quaternion.LookRotation(particulateTransform.forward, inFront * -1);
    }
}
