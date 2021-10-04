using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffJunkController : JunkController
{
    public enum Buffs {
        MOVESPEED, TURNSPEED
    }
    //on attach do something
    //on detach, lose it
    public Buffs buff;
    public int buffValue;

    override protected void  OnAttach()
    {
        PlayerController player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        if (buff == Buffs.MOVESPEED)
        {
            player.movementSpeed += buffValue;
        } else
        {
            player.rotationSpeed += buffValue;
        }
        
    }

    override protected void OnDetach()
    {
        PlayerController player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        if (buff == Buffs.MOVESPEED)
        {
            player.movementSpeed -= buffValue;
        }
        else
        {
            player.rotationSpeed -= buffValue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
