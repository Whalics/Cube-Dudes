using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuzzsawRotate : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Rotate(0,20*speed*Time.deltaTime,0);
    }
}
