using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerCamController : MonoBehaviour {
    public CinemachineVirtualCamera playerCam;

    public float baseOrthographicSize = 5.0f;

    public float smoothTime = 0.5f;

    public float maxSmoothVel = 2f;
    
    private float _zoomVel = 0f;

    // Update is called once per frame
    void Update() {
        var body = GetComponent<Rigidbody2D>();

        var sqrSpeed = body.velocity.sqrMagnitude;

        var desired = Mathf.LerpUnclamped(baseOrthographicSize, 2 * baseOrthographicSize, sqrSpeed / 15);
        var newSize = Mathf.SmoothDamp(playerCam.m_Lens.OrthographicSize, desired, ref _zoomVel, smoothTime, maxSmoothVel);
        playerCam.m_Lens.OrthographicSize = newSize;
        //Debug.Log(newSize);
    }
}
