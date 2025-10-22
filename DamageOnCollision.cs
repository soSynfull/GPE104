using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    public bool instantKill = false;
    public float damageDone = 1.0f;
    public bool selfDestructOnCollision = false;
    private int bulletLayer;
    


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        // Converts a layer name to its numberical index
        bulletLayer = LayerMask.NameToLayer("Bullet");
        Debug.Log("Bullet layer index is: " + bulletLayer);
     
    }

    public void OnCollisionEnter2D (Collision2D collision)
    {
      Health otherObjectHealth = collision.gameObject.GetComponent<Health>();
      MeteorTracking tracker = FindFirstObjectByType<MeteorTracking>();

        Debug.Log("Collision with layer: " + collision.gameObject.layer + " | Expected bulletLayer: " + bulletLayer);

        //if that object exists!
        if (otherObjectHealth != null)
            {
                otherObjectHealth.TakeDamage(damageDone);
            }

            Debug.Log(gameObject + "collided with" + collision.gameObject.name); //Debug log which allows feedback on what is colliding with what

        if (collision.gameObject.layer == bulletLayer)
        {
            if (tracker != null)

            {
                Debug.Log("Bullet hit detected. Attempting to update meteor count.");
                tracker.verifyMeteorDestruction();
                
            }

        }
        // See if we should self destruct?
        if (selfDestructOnCollision == true)
            {
                Destroy(gameObject);
            }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
       
        Pawn affectedPawn = collision.gameObject.GetComponent<Pawn>();
        if (affectedPawn != null && instantKill == true)
        {
            // Getting death componenet  
            Death deathComponent = affectedPawn.GetComponent<Death>();
            if (deathComponent != null)
            {
                Debug.Log("DamageonCollision: Calling Die() on " + affectedPawn.name);
                deathComponent.Die();
            }
            else
            {
                Debug.LogWarning("DamageOnCollision: No Death Component found on " + affectedPawn.name);
            }
        }
    }

 
}

