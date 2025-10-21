using UnityEngine;

public class Health : MonoBehaviour
{
    //Data (variables)
    //Current Health - float 
    private float currentHealth;
    //SerializeField allows health component to edit the max health (will show up in inspector)
    [SerializeField] private float maxHealth;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Start with max Health
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {

            Die();
        }
    }

    public void TakeDamage(float damage, Pawn damageDealer)
    {
        //TODO: Give points to the damage dealer for dealing gamage
        //For now, debug who did the damage
        Debug.Log(damageDealer.gameObject.name + "did" + damage + "damage to" + this.gameObject.name);

        //Actually take the damage
        TakeDamage(damage);
    }

    public void Heal (float healAmount)
    {
        currentHealth = currentHealth + healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void Die ()
    {
        //  Get the death component 
        Death deathComponent = GetComponent<Death>();
        //Tell the death component to die
        if (deathComponent != null)
        {
            deathComponent.Die();
        }
       else
        {
            Debug.LogWarning("Warning: " + gameObject.name + "has no death component");
        }
    }
}
