using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveController : JunkController
{

    public GameObject explosion;
    public float explosionDuration = 2.0f;

    //when an explosive is destroyed -> create a circular hitbox with explosion rad and a sprite of explosion
    //destroy hit box quickly
    //keep effect out a bit longer
    //

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void Explode()
    {
        base.Explode();
        GameObject explosionTemp = Instantiate(explosion, transform.position, Quaternion.Euler(0, 0, 0));
        var force = explosionTemp.GetComponent<PointEffector2D>();
        Destroy(force, .1f);
        Destroy(explosionTemp, explosionDuration);
        
    }

}
