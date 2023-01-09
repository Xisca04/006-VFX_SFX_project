using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float jumForce = 10;

    private bool isOnTheGround = true; // Quita el doble salto y evita que el jugador suba en exceso

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround) 
        {
            isOnTheGround = false;
            _rigidbody.AddForce(Vector3.up * jumForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        isOnTheGround = true;
    }
}
