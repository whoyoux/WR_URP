using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    Transform mainCam;
    private Vector3 offsetFromParent;

    void Start()
    {
        mainCam = Camera.main.transform;
        offsetFromParent = transform.localPosition;
        
    }

    private void LateUpdate()
    {
        // Set the position of the floating text to be above the parent object
        transform.position = transform.parent.position + offsetFromParent;

        // Rotate the floating text to face the camera
        Vector3 dirToCam = mainCam.transform.position - transform.position;
        dirToCam.y = 0;

        if (dirToCam == Vector3.zero) return;

        // Normalize the direction vector
        Quaternion targetRot = Quaternion.LookRotation(-dirToCam, Vector3.up);
        transform.rotation = targetRot;
    }
}
