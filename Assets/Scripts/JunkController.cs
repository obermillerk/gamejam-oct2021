using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkController : CollidableController
{


    public int totalHealth;
    private int currentHealth;
    public float invincibilityTime = 1.0f;
    private float collisionTime = 0;
    public GameObject explosion;
    public Sprite damagedSprite;


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Detach();
            //explosion
            GameObject explosionTemp = Instantiate(explosion, transform.position, Quaternion.Euler(0, 0, 0));

            Destroy(gameObject, 0.25f);
            Destroy(explosionTemp, 1f);
        }
        else if (currentHealth <= totalHealth/2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = damagedSprite;
        }
    }

  

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            TakeDamage(5);
    }


}
