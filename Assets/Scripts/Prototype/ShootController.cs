using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootController : MonoBehaviour
{
    [SerializeField] Vector3 _forceDirection;
    [SerializeField] float _rotateStrength = 25f;
    public float _forceStrength = 0f;
    public bool isShot = false;
    [SerializeField] float _directionChange = 1;
    Camera cam;
    public Rigidbody _rb = null;

    FlickController flickcontroller; 
    
    ForceSliderController forceslidercontroller;
    [SerializeField] GameManager gamemanager;
    //public bool pressed;
    void Start()
    {
        cam = Camera.main;
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        forceslidercontroller = GameObject.Find("ForceStrength_sldr").GetComponent<ForceSliderController>();
        
    }

    void Update(){
    }
    
    public void IncreaseForce(float inc){
        if(!isShot){
            if(_forceStrength < 400f){
                _forceStrength+=inc*Time.deltaTime;
                forceslidercontroller.SetSliderValue(_forceStrength);
            }
        }
    }
    
    public void ShootPlayer(){
        _rb = gamemanager.GetPlayerRb();
        isShot = true;
        gamemanager.FlickVisuals();

        _forceDirection = gamemanager.GetPlayerPos() - cam.transform.position;
        _rb.AddForce(_forceDirection * _forceStrength);
        _rb.AddTorque(_forceDirection);

        _forceStrength=25f;
        StartCoroutine(gamemanager.GetPlayerCollisionController().InMotion());
    }
    
    public void Reset(){
        isShot = false;
        _forceStrength=25f;
        forceslidercontroller.SetSliderValue(_forceStrength);
    }
}
