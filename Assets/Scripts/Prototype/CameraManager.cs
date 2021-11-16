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
    GameManager gamemanager;
    void Start()
    {
        cam = Camera.main;
        turnmanager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        shootcontroller = GameObject.Find("ShootController").GetComponent<ShootController>();
        playercollisioncontroller = turnmanager.players[turnmanager.playerTurn].GetComponent<PlayerCollisionController>();
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        transform.position = gamemanager.GetPlayerPos() + offset;
        rotOffset = Vector3.zero;
        transform.LookAt(gamemanager.GetPlayerTransform());
    }
    
    void FollowPlayer(Transform target){
        transform.position = target.position + rotOffset;
        transform.LookAt(gamemanager.GetPlayerTransform());
        //transform.rotation = camRot;
    }

    public void RotateCamera(float rotx, float roty, float spd){
        transform.Translate(rotx*spd*Time.deltaTime,roty*spd*Time.deltaTime,0);
        //transform.RotateAround(gamemanager.GetPlayerPos(),new Vector3(roty,rotx,0),spd*Time.deltaTime);
        transform.LookAt(gamemanager.GetPlayerTransform());
        rotOffset = new Vector3(transform.position.x - gamemanager.GetPlayerPos().x,Mathf.Abs(transform.position.y - gamemanager.GetPlayerPos().y),transform.position.z - gamemanager.GetPlayerPos().z);
    }
}
