using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    public bool instantKill = false;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D (Collision2D collision)
    {
      Pawn otherPawn = collision.gameObject.GetComponent<Pawn>();
      
      //if that pawn exists!
      if (otherPawn != null)
        {
            otherPawn.health.TakeDamage(3);
        }
      
    
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
       
        Pawn affectedPawn = collision.gameObject.GetComponent<Pawn>();
        if (affectedPawn != null && instantKill == true)
        {
            Destroy(affectedPawn.gameObject);
        }
    }


}

