using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReorientCharacter : MonoBehaviour
{
    public bool reorienting;
    public GameManager gamemanager;

    public float timeElapsed;
    public float lerpDuration = 3;

    public float startValue=0;
    public float endValue=10;

    Vector3 targetposy;
    Quaternion targetRotation;
    Vector3 targetPosition;
    Transform target;
    
    Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {  
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(reorienting)
            Lerp();
    }

    public void SetVariables(){
        target = Camera.main.transform;
        //targetPosition = new Vector3(0,Camera.main.transform.position.y,0);
        targetposy = new Vector3(target.position.x, transform.position.y,target.position.z);
        targetRotation = Quaternion.LookRotation (targetposy - transform.position);
        _rb = this.gameObject.GetComponent<Rigidbody>();
        _rb.AddForce(Vector3.up*15,ForceMode.Impulse);
    }

    void Lerp()
    {
        
        if (timeElapsed < lerpDuration){
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
        }
        else {
        transform.rotation = targetRotation;
        timeElapsed = 0;
        reorienting = false;
        }
    }
}
