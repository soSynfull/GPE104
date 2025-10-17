using UnityEngine;

public class AstreoidMover : MonoBehaviour
{
    public Vector2 moveDirection = Vector2.left;
    public float moveSpeed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime);
    }
}
