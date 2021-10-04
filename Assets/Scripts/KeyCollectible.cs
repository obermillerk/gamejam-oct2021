using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollectible : Collectible
{
    public override void CollectedBy(GameObject other) {
        base.CollectedBy(other);
        Debug.Log("Key collected!");
    }
    
    
}
