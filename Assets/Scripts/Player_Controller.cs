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


    private void GameOver() // Configuracion de la muerte
    {
        gameOver = true;
        _animator.SetBool("Death_b", true);
        _animator.SetInteger("DeathType_int", Random.Range(1,3)); // Genera un numero aleatorio entre 1 y 3, este ultimo no esta incluido, asi que solo entre el 1 y el 2
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
            _animator.SetTrigger("Jump_trig"); // Llama al trigger para que de la animación de correr pase a saltar
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
