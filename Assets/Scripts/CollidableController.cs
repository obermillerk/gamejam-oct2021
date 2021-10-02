using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableController : MonoBehaviour
{

    
    public float mass;
    [SerializeField] private bool attached;
    
    public CollidableController root;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.GetType() + " Collision!");
        Debug.Log("Total Mass of " + gameObject.name + " is: " + PlayerController.totalMass);
        if (other.gameObject.tag == "Junk")
        {
            CollidableController otherCollidable = other.gameObject.GetComponent<CollidableController>();
            // if mass > other mass
            if (attached == true && PlayerController.totalMass >= otherCollidable.mass)
            {
                FixedJoint2D fixedJoint = gameObject.AddComponent<FixedJoint2D>();
                fixedJoint.enableCollision = false;
                fixedJoint.connectedBody = other.rigidbody;
                otherCollidable.Attach();
             
                
                other.rigidbody.mass = 0;
            }
        }

       
        //create a join




    }

    private void Attach()
    {
      
        PlayerController.totalMass += mass;

        attached = true;
    }
    /*
    public void UpdateTotalMass()
    {
        float massSum = mass;
        FixedJoint2D[] fixedJoint2Ds = GetComponents<FixedJoint2D>();
        //Debug.Log("Number of joints: " + fixedJoint2Ds.Length);
        foreach (FixedJoint2D fj in fixedJoint2Ds)
        {
            //each fixed join gets its compoent of mass
            CollidableController otherCollidable = fj.connectedBody.gameObject.GetComponent<CollidableController>();

            //call their update mass functions
            otherCollidable.UpdateTotalMass();


            //adds to sum
            massSum += otherCollidable.totalMass;

        }

        totalMass = massSum;
        Debug.Log("MassSum of " + gameObject.name + " is: " + massSum);
        
    }
    */
}
