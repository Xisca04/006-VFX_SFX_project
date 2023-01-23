using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    //Creacion automatica de los obstaculos
    
    public GameObject[] obstaclePrefabs;
    private float startDelay = 2f;
    private float repeatRate = 3f;

    private Player_Controller playerControllerScript;  // Comunicacion con el script Player_Controller

    private void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);

        playerControllerScript = FindObjectOfType<Player_Controller>();  // Para encontrar el script deseado
    }

    private void SpawnObstacle()
    {
        int randomIdx = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[randomIdx], transform.position, obstaclePrefabs[randomIdx].transform.rotation);
    }

    private void Update()
    {
        if (playerControllerScript.gameOver)
        {
            CancelInvoke("SpawnObstacle");  // Cancela la creacion automatica de los obstaculos si se produce el GAME OVER
        }
    }
}
