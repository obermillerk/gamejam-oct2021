using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CollidableController
{

    public float rotationSpeed;
    public float movementSpeed;
    public static float totalMass;


    // Start is called before the first frame update
    void Start()
    {
        totalMass = mass;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            GetComponent<Rigidbody2D>().AddForce(transform.up * movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            GetComponent<Rigidbody2D>().AddForce(transform.up * -movementSpeed * Time.deltaTime);


        if (Input.GetKey(KeyCode.A))
        {
            var body = GetComponent<Rigidbody2D>();
            body.AddTorque((rotationSpeed * Mathf.Deg2Rad) * body.inertia);
            
        }

            

        if (Input.GetKey(KeyCode.D))
        {
            var body = GetComponent<Rigidbody2D>();
            body.AddTorque((-rotationSpeed * Mathf.Deg2Rad) * body.inertia);
        }
         
    }

    
}
