using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f;



    private void Update()
    {
        // Movement Vector
        Vector2 inputVector = new Vector2 (0, 0);
        // Move Forward
        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1;
        }

        // Move Backward
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }

        // Move Left
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }

        // Move Right
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }

        // To normailse the vector so that the speed is constant
        inputVector = inputVector.normalized;

        // To move in 3D
        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

    }
}