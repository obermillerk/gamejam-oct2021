using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CollidableController
{

    public float rotationSpeed;
    public float movementSpeed;
    public static float totalMass;

    private float cooldown = .5f;
    private float time = 0f;


    // Start is called before the first frame update
    void Start()
    {
        totalMass = mass;
    }

    // Update is called once per frame
    void Update() {
        var body = GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.W))
            body.AddForce(Vector2.up * movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            body.AddForce(Vector2.down * movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            body.AddForce(Vector2.left * movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            body.AddForce(Vector2.right * movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Q))
        {
            body.AddTorque((rotationSpeed * Mathf.Deg2Rad) * body.inertia);
            
        }

            

        if (Input.GetKey(KeyCode.E))
        {
            body.AddTorque((-rotationSpeed * Mathf.Deg2Rad) * body.inertia);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
           // if (time > cooldown)
           // {

                DetachChildren();
           //     time = 0f;
           // }

           // time += Time.deltaTime;
        }

    }

    
}
