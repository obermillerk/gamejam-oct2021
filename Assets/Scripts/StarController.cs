using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {
    void FixedUpdate() {
        var body = GetComponent<Rigidbody2D>();
        
        var particulate = GetComponentInChildren<ParticleSystem>();
        var particulateTransform = particulate.transform;
        var inFront = body.GetVector(body.velocity).normalized;
        // Debug.Log(inFront.sqrMagnitude);
        if (inFront.sqrMagnitude == 0) inFront = new Vector2(0f, 1f);

        var cam = Camera.main;

        Vector2 leftPoint = cam.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
        Vector2 rightPoint = cam.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));
        Vector2 centerPoint = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        var diagLength = (leftPoint - rightPoint).magnitude;

        var viewWidth = rightPoint.x - leftPoint.x;
        var viewHeight = rightPoint.y - leftPoint.y;

        // Debug.Log(viewWidth + ", " + viewHeight);

        var collider = particulate.trigger.GetCollider(0) as BoxCollider;
        // var collider = particulate.trigger.GetCollider(0) as SphereCollider;

        var radius = 0.6f * diagLength;

        collider.size = new Vector3(viewWidth, viewHeight, 10);
        // collider.radius = radius;
        collider.transform.localPosition = body.GetPoint(centerPoint);
        collider.transform.localRotation = Quaternion.Inverse(transform.rotation);
        Debug.DrawLine((Vector2)collider.bounds.min, (Vector2)collider.bounds.max, Color.cyan, 0, false);

        var sh = particulate.shape;
        sh.radius = diagLength;

        inFront = inFront * radius;

        var emission = particulate.emission;
        emission.enabled = false;
        
        particulateTransform.localPosition = new Vector3(inFront.x, inFront.y, particulateTransform.localPosition.z);
        emission.enabled = true;
    }
}
