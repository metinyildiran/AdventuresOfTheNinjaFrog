using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swinging : MonoBehaviour
{
    [SerializeField] private bool rotationRight;
    [SerializeField] private bool nonStop;
    [SerializeField] private float rotationSpeed = 60.0f;

    private void Update()
    {
        if (!nonStop)
        {
            if (transform.rotation.z >= 0.60)
            {
                rotationRight = false;
            }
            else if (transform.rotation.z < -0.60)
            {
                rotationRight = true;
            }
        }
        if (rotationRight)
        {
            transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime, Space.Self);
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, -rotationSpeed) * Time.deltaTime, Space.Self);
        }
    }
}