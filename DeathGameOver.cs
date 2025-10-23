using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DeathGameOver : Death
{



    private void Start()
    {

    }

    public override void Die()
    {
        if (GameManager.instance.currentLives > 1)
        {
            //Subtract a life
            GameManager.instance.currentLives--;
            Debug.Log("DeathGameOver: Lives remaining = " + GameManager.instance.currentLives);


            Destroy(gameObject);
            // Destroy the player and respawn them
            GameManager.instance.StartCoroutine(GameManager.instance.RespawnAfterDeath());   

        }
        else
        {
            GameManager.instance.currentLives = 0;
            Debug.Log("DeathGameOver: No lives left - triggering GameOver");
            GameManager.instance.ShowGameOverScreen();
            Destroy(gameObject);
        }
        //update lives display when a life is lost
        if (GameManager.instance.lifeIcons.Count > 0)
        {
            int lastIndex = GameManager.instance.lifeIcons.Count - 1;

            Destroy(GameManager.instance.lifeIcons[lastIndex]);
            GameManager.instance.lifeIcons.RemoveAt(lastIndex);
        }

       
      
    }

    
}
