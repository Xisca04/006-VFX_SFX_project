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
    
    private Animator _animator;  // Animacion salto del jugador
    

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !gameOver) 
        {
            isOnTheGround = false;
            _rigidbody.AddForce(Vector3.up * jumForce, ForceMode.Impulse);
        }

        _animator.SetTrigger("Jump_trig");
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
        }
        else if (otherCollider.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
        }
    }
}
