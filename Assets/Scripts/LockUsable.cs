using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockUsable : Usable {

    [SerializeField] private KeyCollectible key;
    
    public override bool UseWith(Collectible other) {
        if (other.Equals(key)) {
            Debug.Log("Used the right key!");
            Destroy(gameObject);
            return true;
        }

        return base.UseWith(other);
    }
}
