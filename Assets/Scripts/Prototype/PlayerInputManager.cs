using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public InputAction inputController;
    [SerializeField] Vector2 movementInput = Vector2.zero;
    public bool flicked;
    public float flicking;
    public bool moving;
    public bool movePressed;
    public float turnHold;
    [SerializeField] ShootController shootcontroller;
    [SerializeField] CameraManager cameramanager;
    [Tooltip("Does not auto assign")]
    [SerializeField] TurnSliderController turnslidercontroller;
    [SerializeField] TurnManager turnmanager;
    [SerializeField] float panSpeed;
    public float sliderIncreaseAmount;
    
    [Tooltip("Disables player input when true, except for the select button to begin the turn.")]
    public bool disableControls;

    public float forceIncrease;
    // Start is called before the first frame update
    void Start()
    {
        shootcontroller = GameObject.Find("ShootController").GetComponent<ShootController>();
        cameramanager = GameObject.Find("CameraRotator").GetComponent<CameraManager>();
        turnmanager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
    }
   
    
    public void OnMove(InputAction.CallbackContext context){
        if(!disableControls)
        movementInput = context.ReadValue<Vector2>();
        if(Mathf.Abs(movementInput.y) > 0 || Mathf.Abs(movementInput.x) > 0){
            movePressed = true;
        }
        else
            movePressed = false;
        //cameramanager.InvokeRepeating("RotateCamera",0f,0.02f);
        //cameramanager.RotateCamera(movementInput.x,-movementInput.y,panSpeed);
    }
    public void Moving(){
        moving = true;
    }

    public void Flick(InputAction.CallbackContext context){
        if(!disableControls)
        flicked = !context.ReadValue<bool>();
    }

    public void Hold(InputAction.CallbackContext context){
        if(disableControls)
        turnHold = context.ReadValue<float>();
    }

    public void OnFlickDown(InputAction.CallbackContext context){
        if(!disableControls && !flicked)
        flicking = context.ReadValue<float>();
    }
    
    void Update()
    {

        if(disableControls){ //ensures turn values (force slider, etc) get reset during turn window
            flicking = 0f;
            flicked = false;
            movementInput = Vector2.zero;
            shootcontroller.Reset();
        }
        if(flicked && flicking == 0){
            flicked = false;
        }
        

        if(movePressed){
            cameramanager.RotateCamera(-movementInput.x,movementInput.y,panSpeed);
        }

        Debug.Log(shootcontroller._forceStrength);
        if(flicking > 0){
            // flicked = true;
            shootcontroller.IncreaseForce(forceIncrease);
        }
        if(flicked && shootcontroller._forceStrength > 26){
             shootcontroller.ShootPlayer();
        }
        if(disableControls && turnHold > 0){
            Debug.Log("button pressed");
            turnslidercontroller.IncreaseValue(sliderIncreaseAmount);
        }
        else if(turnHold == 0)
            turnslidercontroller.ResetSlider();

        if(turnslidercontroller.sliderVal >= 1){
            turnHold = 0;
            turnslidercontroller.ResetSlider();
            StartCoroutine(turnmanager.NextTurn());
            
            
        }
    }
    
    public void Reset(){
        flicked = false;
        flicking = 0;
    }
}
