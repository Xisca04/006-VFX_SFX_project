using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    //Repeticion imagen del fondo

    private Vector3 startPos;
    private float repeatWidith; // Anchura de una unidad de fondo

    private void Start()
    {
        startPos = transform.position;
        repeatWidith = GetComponent<BoxCollider>().size.x / 2;
    }

    private void Update()
    {
        if(transform.position.x <startPos.x - repeatWidith)
        {
            transform.position = startPos;
        }
    }
}
