using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    public void QuitButton()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.QuitGame();
        }
    }

    public void StartButton()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.StartGameplay();

        }
    }
}
