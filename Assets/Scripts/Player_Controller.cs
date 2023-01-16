using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    //Control del salto del jugador
    
    private Rigidbody _rigidbody;
    public float jumForce = 10;

    private bool isOnTheGround = true; // Quita el doble salto y evita que el jugador suba en exceso
    public bool gameOver;

    // Animacion salto del jugador
    private Animator _animator;  
    public float gravityModifier = 1.5f;

    // private int randomNumber;

    private void GameOver() // Configuracion de la muerte
    {
        gameOver = true;
        _animator.SetBool("Death_b", true);
        _animator.SetInteger("DeathType_int", 1);

        // Generar numero aleatorio para la muerte
        // randomNumber = Random.Range(1, 2);
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;     
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !gameOver) 
        {
            isOnTheGround = false;
            _rigidbody.AddForce(Vector3.up * jumForce, ForceMode.Impulse);
            _animator.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
        else if (otherCollider.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
        }
    }
}
