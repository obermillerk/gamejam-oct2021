using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : JunkController
{

    public float cooldown;
    private float time;
    public Sprite weaponSprite;
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        PlayerController player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        time += Time.deltaTime;
        if (time > cooldown)
        {
            time = 0;

            Vector3 targetDirection = (player.transform.position - transform.position).normalized;
            //create an explosive //position towards the player // rotated towards the player

            GameObject tempBullet = Instantiate(bullet, transform.position + targetDirection * 1.1f, Quaternion.LookRotation(targetDirection));
            //send it towards player
            var bulletBody = tempBullet.GetComponent<Rigidbody2D>();
            bulletBody.velocity = targetDirection * 2f;
            bulletBody.drag = 0;
            //destroy it after a certain time
            Destroy(tempBullet, 3f);
        }
    }
}
