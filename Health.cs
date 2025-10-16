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

    public void TakeDamage (float damage)
    {
        currentHealth -= damage; //current health = current health - damage
        if (currentHealth <= 0)
        {
            Die();
        }
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
        // TODO: Get the death component 
        //TODO: Tell the death component to die
        Debug.Log("You got me!");
    }
}
