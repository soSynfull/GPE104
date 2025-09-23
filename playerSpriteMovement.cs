using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spriteMovement : MonoBehaviour
{
    private Transform tf; // A variable to hold our transfrom component
    public float speed; // Allows variable to be seen from editor
    public float turnSpeed;
    public float turbo;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
     
        Vector3 direction = Vector3.zero;
        
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.up;
            Debug.Log(" W pressed");
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.down;
            Debug.Log(" S pressed");
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
            Debug.Log(" A pressed");
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
            Debug.Log(" D pressed");
        }
       
        transform.position += direction.normalized * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, 0, turnSpeed); // Allows for "turnSpeed" counter-clockwise
            Debug.Log(" Rotating Left");
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 0, -turnSpeed); // Allows for "turnSpeed" clockwise
            Debug.Log(" Rotating Right");
        }

    if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += direction.normalized * speed * turbo * Time.deltaTime;
        }
        
    }
}
