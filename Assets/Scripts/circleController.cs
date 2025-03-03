using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleController : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;

    private void Update()
    {
        setCircleRotate();
    }

    private void setCircleRotate()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
}
