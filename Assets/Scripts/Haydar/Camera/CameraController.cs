using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float cameraSpeed;
    public Vector3 distance;

    void LateUpdate()
    {
        
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

        
        transform.position = Vector3.Lerp(transform.position, targetPosition + distance, cameraSpeed * Time.deltaTime);
    }
}
