using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCameraTest : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    //public float strength = .5f;
    public Rigidbody rb;
    //public LayerMask L_Ground;
    //Vector3 hitpos;
    //Vector3 up;

    float timeElapsed;
    float lerpDuration = 3;

    float startValue=0;
    float endValue=10;
    float valueToLerp;

 void Start(){
     //SetHitLoc();

     rb.AddForce(Vector3.up*15,ForceMode.Impulse);
 }
// void Update () {
    
//     float str = Mathf.Min (strength * Time.deltaTime, 1);
//     transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, str);
//     //transform.position = Vector3.Lerp(transform.position,up,str);
//     rb.angularVelocity = Vector3.zero;
//     rb.velocity = Vector3.zero;
// }
void Update(){
    Lerp();
}

// void SetHitLoc(){
//     RaycastHit hit;
//     Debug.DrawRay(transform.position+Vector3.up, Vector3.down*20, Color.red,20f);
//     if(Physics.Raycast(transform.position+Vector3.up,Vector3.down, out hit, 20,L_Ground)){
//         hitpos = hit.point;
//         up = new Vector3(transform.position.x,hitpos.y+0.3f,transform.position.z);
//     }
// }
 void Lerp()
  {
    Vector3 targetposy = new Vector3(target.position.x, transform.position.y,target.position.z);
    Quaternion targetRotation = Quaternion.LookRotation (targetposy - transform.position);
    if (timeElapsed < lerpDuration)
    {
      transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, timeElapsed / lerpDuration);
      timeElapsed += Time.deltaTime;
    }
    else 
    {
      valueToLerp = endValue;
    }
  }
}
