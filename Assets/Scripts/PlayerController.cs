using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float rotationSpeed;
    public float movementSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            GetComponent<Rigidbody2D>().AddForce(transform.up * movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            GetComponent<Rigidbody2D>().AddForce(transform.up * -movementSpeed * Time.deltaTime);


        if (Input.GetKey(KeyCode.A))
            transform.Rotate(new Vector3(0,0,1) * rotationSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(new Vector3(0, 0,-1) * rotationSpeed * Time.deltaTime);
    }
}
