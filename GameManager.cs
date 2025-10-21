using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;



    [Header("Players")]
    // List of players
    public List<spriteMovement> players;

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
    public int maxLives;
    public int currentLives;
    public List<Transform> meteorSpawnPoints;

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
        //Make the Player list
        players = new List<spriteMovement>();

        //Spawn the Player Controller
        SpawnPlayerController();

        //Spawn the Player Pawn
        SpawnPlayer();

        //InvokeRepeating allows the function to be called mulitple times at a specified rate ("MethodName, start delay, repeatRate)
        InvokeRepeating("SpawnMeteor", .5f, 3f); 
    }

    public void Update()
    {
        
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
        // If the player currently has a pawn (is still alive), destroy it
        if (players[0].pawnObject != null)
        {
            Destroy(players[0].pawnObject);
        }

        // Instantiate a player pawn
        GameObject newPawnObject = Instantiate(playerPawnPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        if (newPawnObject != null) 
        {
            Pawn newPawn = newPawnObject.GetComponent<Pawn>();
            if (newPawn != null)
            {
                players[0].pawnComponent = newPawn;
            }

        }
        

    }

}
