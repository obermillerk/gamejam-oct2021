using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkController : CollidableController
{


    
    private bool exploding;
    private int currentHealth;
    public int totalHealth;

    public Sprite damagedSprite;
    public Sprite destroyedSprite;
    

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        
        base.OnCollisionEnter2D(other);
        
        if (other.gameObject.tag == "Explosion")
        {

            Debug.Log("InExplosion");
            ExplosionController explosion = other.gameObject.GetComponent<ExplosionController>();
            //TakeDamage
            TakeDamage(explosion.damage);
        }
    }

    public void TakeDamage(int damage)
    {
        //Debug.Log(gameObject.name + " has: " + currentHealth + " health!");
        OnDamage();
        currentHealth -= damage;
        Debug.Log(gameObject.name + " has: " + currentHealth + " health!");
        if(currentHealth <= 0 && !exploding)
        {
            if (IsAttached())
            {
                Detach();
            }
            
            //explosion
            //GameObject explosionTemp = Instantiate(explosion, transform.position, Quaternion.Euler(0, 0, 0));
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = destroyedSprite;
            Explode();
            Destroy(gameObject, 0.1f);

        }
        else if (currentHealth <= totalHealth/2)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = damagedSprite;
        }
    }

  

    // Start is called before the first frame update
    virtual protected void Start()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        exploding = false;
        currentHealth = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            TakeDamage(5);
    }

    public virtual void Explode()
    {
        exploding = true;
    }

    virtual protected void OnDamage()
    {

    }
}
