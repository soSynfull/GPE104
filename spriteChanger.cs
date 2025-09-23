using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteChanger : MonoBehaviour
{
    // Declare our Variables
    private SpriteRenderer theRenderer; // Variable for our renderer
    public Color spriteColor; // variable for our Color


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Load the spriteRenderer component from the same object this component is on
        theRenderer = gameObject.GetComponent<SpriteRenderer>();
        //Change the color from our color picker so that the alpha (.a) is 1
        spriteColor.a = 1.0f;
        // As long as theRenderer has been set
        if (theRenderer != null) 
        {
            // Change the "color" value of our SpriteRenderer components to green
            theRenderer.color = Color.green;
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
