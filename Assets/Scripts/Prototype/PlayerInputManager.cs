using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public InputAction inputController;
    Vector2 movementInput = Vector2.zero;
    public bool flicked;
    public float flicking;
    public bool moving;
    [SerializeField] ShootController shootcontroller;
    [SerializeField] CameraManager cameramanager;
    [SerializeField] float panSpeed;
    public float forceIncrease;
    // Start is called before the first frame update
    void Start()
    {
        shootcontroller = GameObject.Find("ShootController").GetComponent<ShootController>();
        cameramanager = GameObject.Find("CameraRotator").GetComponent<CameraManager>();
    }

    public void OnMove(InputAction.CallbackContext context){
       movementInput = context.ReadValue<Vector2>();
       cameramanager.RotateCamera(movementInput.x,-movementInput.y,panSpeed);
    }
    public void Moving(){
        moving = true;
    }

    public void Flick(InputAction.CallbackContext context){
        flicked = !context.ReadValue<bool>();
    }

    public void OnFlickDown(InputAction.CallbackContext context){
        flicking = context.ReadValue<float>();
    }
    
    void Update()
    {
        Debug.Log(shootcontroller._forceStrength);
        if(flicking > 0){
            // flicked = true;
            shootcontroller.IncreaseForce(forceIncrease);
        }
        if(flicked && shootcontroller._forceStrength > 26){
             shootcontroller.ShootPlayer();
         }
    }
    
    public void Reset(){
        flicked = false;
        flicking = 0;
    }
}
