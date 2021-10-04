using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockUsable : Usable {

    [SerializeField] private KeyCollectible key;

    [SerializeField] private GameObject forceField;
    
    public override bool UseWith(Collectible other) {
        if (other.Equals(key)) {
            Debug.Log("Used the right key!");
            Destroy(gameObject);

            var emission = forceField.GetComponent<ParticleSystem>().emission;
            emission.enabled = false;
            Destroy(forceField, 1f);
            return true;
        }

        return base.UseWith(other);
    }
}
