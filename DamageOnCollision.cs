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
    public float scoreValue = 100f;
    private bool hasScored = false;
    private AudioSource audioSource;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

    /* this if statement allows the following code to function only if hasScored is true. 
     * Once set within the collision.gameObject.CompareTag("Bullet") if statement, it allows for
     * the collision to work properly. return; allows the first if(hasScored) to exit the method
     * early, preventing accidental collisions */

        if (hasScored)
        {
            return;
        }
        
        
       if (collision.gameObject.CompareTag("Bullet"))
        {
            hasScored = true; 

            Health otherObjectHealth = collision.gameObject.GetComponent<Health>();

            //if that object exists!
            if (otherObjectHealth != null)
            {
                otherObjectHealth.TakeDamage(damageDone);
            }
            // Adding score via GameManager
            if (GameManager.instance != null)
            {
                GameManager.instance.AddScore(scoreValue);
            }

            Debug.Log(gameObject + "collided with" + collision.gameObject.name); //Debug log which allows feedback on what is colliding with what

            MeteorTracking tracker = FindFirstObjectByType<MeteorTracking>();

            Debug.Log("Collision with layer: " + collision.gameObject.layer + " | Expected bulletLayer: " + bulletLayer);

            if (tracker != null)

            {
                Debug.Log("Bullet hit detected. Attempting to update meteor count.");
                tracker.verifyMeteorDestruction();

            }

            // See if we should self destruct?
            if (selfDestructOnCollision == true)
            {
                 audioSource.Play();
                Destroy(gameObject, audioSource.clip.length);
                
            }
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

