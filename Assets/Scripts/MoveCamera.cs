using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField]
    private Transform cameraPosition;
    [SerializeField] 
    private float followSpeed = 10f;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, cameraPosition.position, followSpeed * Time.deltaTime);
    }
}
