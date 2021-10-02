using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkController : MonoBehaviour
{

    public float mass;
    public float health;
    public float invincibilityTime = 1.0f;
    private float collisionTime = 0;

    private void OnCollisionStay(Collision other)
    {
        Debug.Log(other.GetType());
        if (other.gameObject.tag == "Player")
        {

            if (collisionTime < invincibilityTime)
            {

                collisionTime += Time.deltaTime;

            }
            else
            {
                /*
                currentTime = 0f;

                HealthController healthController = other.gameObject.GetComponent<HealthController>();

                if (healthController != null)
                {
                    healthController.DealDamage(damage);
                }
                */

            }

        }

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
