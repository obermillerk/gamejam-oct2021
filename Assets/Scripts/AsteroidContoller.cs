using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidContoller : JunkController
{

    public Sprite[] sprites;
    

    public float maxScale;
    public float minScale;


    public float maxSpeed;
    public float minSpeed;
    private float speed;

    public float maxAngularVelocity;
    public float minAngularVelocity;
    private float angularVelocity;

    


    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        float scaleFactor = Random.Range(minScale, maxScale);
        gameObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, 0);
        mass *= scaleFactor;
      
        //select random sprite within range
        GetComponentInChildren<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        //select random velocity within range
        speed = Random.Range(minSpeed, maxSpeed);
        //select random angular velecity within range
        angularVelocity = Random.Range(minAngularVelocity, maxAngularVelocity);

        var body = GetComponent<Rigidbody2D>();
        body.velocity = transform.up * speed;
        body.angularVelocity = angularVelocity;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
