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
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            GetComponent<Rigidbody2D>().AddForce(transform.up * movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            GetComponent<Rigidbody2D>().AddForce(transform.up * -movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            GetComponent<Rigidbody2D>().AddForce(transform.right * -movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            GetComponent<Rigidbody2D>().AddForce(transform.right * movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Q))
        {
            var body = GetComponent<Rigidbody2D>();
            body.AddTorque((rotationSpeed * Mathf.Deg2Rad) * body.inertia);
            
        }

            

        if (Input.GetKey(KeyCode.E))
        {
            var body = GetComponent<Rigidbody2D>();
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
