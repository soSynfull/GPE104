using UnityEngine;

public class UIGameOver : MonoBehaviour
{
   public void MainMenuButton()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ShowMainMenu();
        }
    }


}
