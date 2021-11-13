using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public Vector3 offset;
    public Vector3 rotOffset;
    public Quaternion camRot;
    public Camera cam;
    ShootController shootcontroller;
    TurnManager turnmanager;
    PlayerCollisionController playercollisioncontroller;

    void Start()
    {
        cam = Camera.main;
        turnmanager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        shootcontroller = GameObject.Find("ShootController").GetComponent<ShootController>();
        playercollisioncontroller = turnmanager.players[turnmanager.playerTurn].GetComponent<PlayerCollisionController>();
    }

    void Update()
    {
        if(shootcontroller.isShot && !playercollisioncontroller.hasCollided)
            FollowPlayer(turnmanager.players[turnmanager.playerTurn].transform);
        else if(!shootcontroller.isShot && !playercollisioncontroller.hasCollided){
            //this is where we run movecamera input detection, so we cant move if the player has been shot. but i think we dont want this
        }
    }

    public void MoveToPlayer(){
        transform.position = turnmanager.players[turnmanager.playerTurn].transform.position + offset;
        rotOffset = Vector3.zero;
        transform.LookAt(turnmanager.players[turnmanager.playerTurn].transform);
    }
    
    void FollowPlayer(Transform target){
        transform.position = target.position + rotOffset;
        transform.LookAt(turnmanager.players[turnmanager.playerTurn].transform);
        //transform.rotation = camRot;
    }

    public void RotateCamera(float rotx, float roty, float spd){
        transform.Translate(rotx*spd,roty*spd,0);
        // transform.Translate(roty);
        transform.LookAt(turnmanager.players[turnmanager.playerTurn].transform);
        rotOffset = new Vector3(transform.position.x - turnmanager.players[turnmanager.playerTurn].transform.position.x,Mathf.Abs(transform.position.y - turnmanager.players[turnmanager.playerTurn].transform.position.y),transform.position.z - turnmanager.players[turnmanager.playerTurn].transform.position.z);
        //camRot = transform.rotation; 
    }
}
