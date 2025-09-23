using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameQuiter : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Debug.Log("Game has ended");
        }
        else
            Application.Quit();
      
    }
}
