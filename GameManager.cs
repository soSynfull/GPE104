using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public bool isRespawning = false;
    
    public static GameManager instance;
  
   



    [Header("Players")]
    // List of players
    public List<spriteMovement> players;

    [Header("UI")]
    public TextMeshProUGUI scoreText;
    public GameObject lifeIcon;
    public Transform livesPanel;
    //Allows us to grab the initial loction of the gameobject within our canvas 
    public List<GameObject> lifeIcons = new List<GameObject>();

    [Header("Prefabs")]
    // List of prefabs
    public GameObject playerPawnPrefab;
    public GameObject playerControllerPrefab;
    public GameObject meteorPrefab;
    public GameObject bulletPrefab;

    [Header("Game Data")]
    //Any other variable that our game needs
    public float score;
    public float topScore;
    public int startLives = 3;
    public int currentLives;
    public List<Transform> meteorSpawnPoints;

    [Header("Game States")]
    public GameObject mainMenuObject;
    public GameObject gameplayObject;
    public GameObject gameOverObject;

    public void Awake()
    {
        // Is there anything in the shared instance variable????
        if (instance != null)
        {
            // Self destruct!
            Destroy(gameObject);
        }
        else
        {
            // Else, there is no game manager yet --we are the first one -- save that we exist
            instance = this;

        }
    }

    public Vector3 GetRandomSpawnPoint()
    {
        return (meteorSpawnPoints[Random.Range(0, meteorSpawnPoints.Count)].position);
    }

    public void SpawnMeteor()
    {
        GameObject newMeteor = Instantiate(meteorPrefab,
                                            GetRandomSpawnPoint(), 
                                            Quaternion.identity) as GameObject;
        newMeteor.transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
    }

    public void Start()
    {
        ShowMainMenu();
    }

    public void Update()
    {
        // If we are in gamplay mode
        if (gameplayObject.activeInHierarchy)
        {
         
            // Do our gameplay stuff
            GameplayStuff();
        }

    }
    public void GameplayStuff()
    {

        //Do our gameplay stuff
        // TODO: Update the GameUI

        // If the play has been destroyed, show game over screen
        if (isRespawning || players[0].pawnObject == null)
        {
            return;
        }
        if (players[0].pawnObject == null)
        {
            Debug.Log("GameplayStuff: Triggering GameOver — pawnComponent is null");
            ShowGameOverScreen();
        }
        
        // Updates the score during gameplay
        if (scoreText != null)
        {
            scoreText.text = "Score: " + Mathf.FloorToInt(score);
        }
    }
       
        
      
      
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void SpawnPlayerController()
    {
        //Instantiate our player and get the controller component
        GameObject newControllerObject = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity);
        spriteMovement newControllerPlayerComponent = newControllerObject.GetComponent<spriteMovement>();
        // store controller component in player 0
        players.Add(newControllerPlayerComponent);
    }

    public void SpawnPlayer()
    {
        Debug.Log("SpawnPlayer: players.count" + players.Count);
        // If the player currently has a pawn (is still alive), destroy it
        if (players[0].pawnObject != null)
        {
            Destroy(players[0].pawnObject);
        }

        // Instantiate a player pawn
        GameObject newPawnObject = Instantiate(playerPawnPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        Debug.Log("SpawnPlayer: newPawnObject = " + newPawnObject);
        if (newPawnObject != null) 
        {
            Pawn newPawn = newPawnObject.GetComponent<Pawn>();
            Debug.Log("SpawnPlayer: newPawn = " + newPawn);
            if (newPawn != null)
            {
                players[0].pawnComponent = newPawn;
                players[0].pawnObject = newPawnObject;
                Debug.Log("SpawnPlayer: Assigned pawnComponent = " + players[0].pawnComponent);

            }

        }


    }

    public void ShowMainMenu()
    {
        // Turn off gameplay screen
        gameplayObject.SetActive(false);
        //Turn off gameover screen
        gameOverObject.SetActive(false);
        //Turn on MainMenu
        mainMenuObject.SetActive(true);
    }

    public void ShowGameOverScreen()
    {
        //Turn off gameplay screen
        gameplayObject.SetActive(false);
        //Turn off Main Menu Screen 
        mainMenuObject.SetActive(false);
        //Turn on Game Over Screen
        gameOverObject.SetActive(true);
    }


    public void StartGameplay() 
    {
        Debug.Log("StartGameplay: Called");
        //Turn off the main menu
        mainMenuObject.SetActive(false);
        // Turn off the game over screen (if its running)
        gameOverObject.SetActive(false);
        // Turn ON the gameplay screen
        gameplayObject.SetActive(true);
        //Make the Player list
        players = new List<spriteMovement>();

        //Spawn the Player Controller
        SpawnPlayerController();

        //Spawn the Player Pawn
        SpawnPlayer();

        // Set players lives to starting lives
        currentLives = startLives;

        //InvokeRepeating allows the function to be called mulitple times at a specified rate ("MethodName, start delay, repeatRate)
        InvokeRepeating("SpawnMeteor", .5f, 3f);

        //Initializing lives display
        // Clear old icons
        foreach (GameObject icon in lifeIcons)
        {
            Destroy(icon);
           
        }
        lifeIcons.Clear();

        // Create icons for current lives
        for (int i = 0; i < currentLives; i++)
        {
            GameObject icon = Instantiate(lifeIcon, livesPanel);
            lifeIcons.Add(icon);

        }
    }
    // Declares a coroutine method that can pause exectution and resume later
    public IEnumerator RespawnAfterDeath()
    {
        GameManager.instance.isRespawning = true;

        yield return null;

        GameManager.instance.SpawnPlayer();
        GameManager.instance.isRespawning = false;
        Debug.Log("RespawnAfterDeath: Calling SpawnPlayer(");
    }
}
