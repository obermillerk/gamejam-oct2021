using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : JunkController
{

    //contents of create
    public List<GameObject> contents =  new List<GameObject>();
    //when damaged, spawn one piece of content flying away from crate


    //when an explosive is destroyed -> create a circular hitbox with explosion rad and a sprite of explosion
    //destroy hit box quickly
    //keep effect out a bit longer
    //

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void Explode()
    {
         base.Explode();
         while (contents.Count > 0)
         {
                OnDamage();
         }
            
      
    }

    protected override void OnDamage()
    {
        base.OnDamage();
        if (contents.Count > 0)
        {
            GameObject randomJunk = contents[Random.Range(0, contents.Count)];
            //create object and remove from list                                  //diameter of object
            GameObject spawned = Instantiate(randomJunk, transform.position + (Vector3)Random.insideUnitCircle.normalized * 5, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            spawned.GetComponent<Rigidbody2D>().velocity = transform.up * 3;

            contents.Remove(randomJunk);
        }
    }
}
