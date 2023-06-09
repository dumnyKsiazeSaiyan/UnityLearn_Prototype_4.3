using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up, Time.deltaTime * horizontalInput * rotationSpeed );
    }
}
