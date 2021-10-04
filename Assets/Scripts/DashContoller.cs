using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashContoller : JunkController
{


    public float cooldown;
    private float time;
    public Sprite dashSprite;
    private Sprite sprite;
    private int dashCount = 0;

    // Update is called once per frame
    void Update()
    {
        PlayerController player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        if (time > cooldown / 10 )
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
        }

        time += Time.deltaTime;
        if (time > cooldown && Vector3.Distance(player.transform.position, transform.position) < 100 && !IsAttached())
        {
            dashCount++;
            if (dashCount % 3 == 0)
            {
                Sprite currentSprite = gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
                gameObject.GetComponentInChildren<SpriteRenderer>().sprite = dashSprite;
            }
            
            time = 0;

            Vector3 targetDirection = (player.transform.position - transform.position).normalized;
            //create an explosive //position towards the player // rotated towards the player

            //send it towards player
            var myBody = GetComponent<Rigidbody2D>();
            myBody.velocity = targetDirection * 15f;

            transform.rotation = Quaternion.LookRotation(transform.forward, targetDirection);
            //bulletBody.drag = 0;
            //destroy it after a certain time
            // Destroy(tempBullet, 3f);
        }
    }

    protected void Start()
    {
        base.Start();
        sprite = gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
    }
}
