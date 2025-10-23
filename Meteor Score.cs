using Unity.VisualScripting;
using UnityEngine;

public class MeteorScore : MonoBehaviour
{
    public float scoreValue = 100f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Adding score via GameManager
            if (GameManager.instance != null)
            {
                GameManager.instance.AddScore(scoreValue);
            }
            
        }

        
    }
}
