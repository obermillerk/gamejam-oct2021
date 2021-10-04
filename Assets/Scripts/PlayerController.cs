using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CollidableController
{

    public float rotationSpeed;
    public float movementSpeed;
    public float totalMass;

    private readonly List<Collectible> m_carrying = new List<Collectible>(1);


    // Start is called before the first frame update
    void Start()
    {
        totalMass = mass;
    }

    // Update is called once per frame
    void Update() {
        var body = GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.W))
            body.AddForce(Vector2.up * movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            body.AddForce(Vector2.down * movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            body.AddForce(Vector2.left * movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            body.AddForce(Vector2.right * movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Q))
        {
            body.AddTorque((rotationSpeed * Mathf.Deg2Rad) * body.inertia);
            
        }

            

        if (Input.GetKey(KeyCode.E))
        {
            body.AddTorque((-rotationSpeed * Mathf.Deg2Rad) * body.inertia);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
           // if (time > cooldown)
           // {

                DetachChildren();
           //     time = 0f;
           // }

           // time += Time.deltaTime;
        }

    }

    void OnTriggerEnter2D(Collider2D other) {
        var otherObject = other.gameObject;

        TriggerCollectible(otherObject);
        TriggerUsable(otherObject);
    }

    private void TriggerCollectible(GameObject otherObject) {
        if (!otherObject.TryGetComponent(out Collectible collectible)) return;
        m_carrying.Add(collectible);
        collectible.CollectedBy(gameObject);
    }

    private void TriggerUsable(GameObject otherObject) {
        if (!otherObject.TryGetComponent(out Usable usable) || usable.Use() || m_carrying.Count <= 0) return;
            
        foreach (var collected in m_carrying) {
            if (!usable.UseWith(collected)) continue;
            
            collected.Use();
            m_carrying.Remove(collected);
            return;
        }
    }

    
}
