using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmooth : MonoBehaviour
{
    [SerializeField] GameObject camParent;
    [SerializeField] float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        SmoothTransform();
    }

    void SmoothTransform(){
        Vector3 camPosition = camParent.transform.position;
        Vector3 smoothCamPosition = Vector3.Lerp(transform.position, camPosition, smoothSpeed);
        transform.position = smoothCamPosition;

        Quaternion camRotation = camParent.transform.rotation;
        Quaternion smoothCamRotation = Quaternion.Lerp(transform.rotation,camRotation,smoothSpeed);
        transform.rotation = smoothCamRotation;
    }
}
