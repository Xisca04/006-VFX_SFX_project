using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Movimiento lateral de los obstaculos hacia la izquierda

    public float speed = 30f;

    private Player_Controller playerControllerScript;  // Comunicacion con el script Player_Controller

    public float leftBound;

    private void Start()
    {
        playerControllerScript = FindObjectOfType<Player_Controller>();
    }

    private void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))  //Destruye los obstaculos si salen del limite
        {
            Destroy(gameObject);
        }
    }
}
