using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkController : CollidableController
{


    public int totalHealth;
    private int currentHealth;
    public float invincibilityTime = 1.0f;
    private float collisionTime = 0;
   // public GameObject explosion;
    public Sprite damagedSprite;
    public Sprite destroyedSprite;
    private bool exploding;


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
        currentHealth -= damage;
        if(currentHealth <= 0 && !exploding)
        {
            Detach();
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
    void Start()
    {
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
}
