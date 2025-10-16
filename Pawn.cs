using UnityEngine;

public class Pawn : MonoBehaviour
{
    public Health health; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    protected virtual void Start() //virtual allows the possibility of the function to be overwritten by child class
    {
        //Load the health component
        health = GetComponent<Health>();
        //Verify that the health component was "obtained"
        if (health == null)
        {
            Debug.LogWarning(gameObject.name + " does not have a health component");
        }
    }
  
    // Update is called once per frame
    void Update()
    {
        
    }
}
