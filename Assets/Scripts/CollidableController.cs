using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableController : MonoBehaviour
{

    
    public float mass;
    [SerializeField] private bool attached;

    protected List<CollidableController> children = new List<CollidableController>();
    
   // public CollidableController root;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log(other.GetType() + " Collision!");
        //Debug.Log("Total Mass of " + gameObject.name + " is: " + PlayerController.totalMass);
        Debug.Log("InCollidable");
        if (other.gameObject.tag == "Junk")
        {

            JunkController otherCollidable = other.gameObject.GetComponent<JunkController>();
            Rigidbody2D thisRigid = gameObject.GetComponent<Rigidbody2D>();
            Rigidbody2D otherRigid = other.gameObject.GetComponent<Rigidbody2D>();
            var differenceInMag = (otherRigid.velocity * otherCollidable.mass - thisRigid.velocity * mass).sqrMagnitude;
            if (differenceInMag > 0f)
            {
                Debug.Log(gameObject.name + " has dealt " + other.gameObject.name + " " + (int)mass/2 + " damage!");
                otherCollidable.TakeDamage((int)mass/2); 
            }
            // if mass > other mass
            if (attached && !otherCollidable.attached && PlayerController.totalMass >= otherCollidable.mass)
            {
                
                FixedJoint2D fixedJoint = gameObject.AddComponent<FixedJoint2D>();
                fixedJoint.enableCollision = false;
                fixedJoint.connectedBody = other.rigidbody;
                otherCollidable.Attach();

                children.Add(otherCollidable);
             
                
                other.rigidbody.mass = 0;

                Debug.Log(gameObject.name + " has connected to " + other.gameObject.name + "!");
                Debug.Log(gameObject.name + " has " + children.Count + " children!");
            }
        } 
        



       
        //create a join




    }

    public void setMass(float newMass)
    {
        mass = newMass;
    }

    protected void Attach()
    {
        //GameController
        PlayerController.totalMass += mass;

        attached = true;

        Debug.Log("Inside Attach: " + gameObject.name + ", Total Mass of Player is: " + PlayerController.totalMass);
    }

    protected void Detach()
    {
        
        //Debug.Log("Inside Detach for: " + gameObject.name);
        attached = false;
        PlayerController.totalMass -= mass;
        Debug.Log("Inside Detach: " + gameObject.name + ", Total Mass of Player is: " + PlayerController.totalMass);
        while (children.Count > 0)
        //foreach (CollidableController cc in children)
        {
            children[0].Detach();
            //cc.Detach();
            Destroy(gameObject.GetComponent<FixedJoint2D>());
            children.Remove(children[0]);
        }


    }

    protected void DetachChildren()
    {
        Debug.Log("Inside Detach Children: " + gameObject.name + ", Total Mass of Player is: " + PlayerController.totalMass);
        while(children.Count > 0)
        //foreach (CollidableController cc in children)
        {
            children[0].Detach();
            //cc.Detach();
            Destroy(gameObject.GetComponent<FixedJoint2D>());
            children.Remove(children[0]);
        }
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
