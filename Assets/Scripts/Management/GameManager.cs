using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TurnManager turnmanager;
    [SerializeField] ShootController shootcontroller;
    [SerializeField] PlayerCollisionController playercollisioncontroller;
    [SerializeField] FlickController flickcontroller;
    [SerializeField] TimerController timercontroller;
    [SerializeField] CharacterClass characterclass;
    [SerializeField] PlayerInputManager playerinputmanager;

    void Start()
    {
        turnmanager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        shootcontroller = GameObject.Find("ShootController").GetComponent<ShootController>();
        playercollisioncontroller = GetPlayer().GetComponent<PlayerCollisionController>();
        flickcontroller = GameObject.Find("Finger").GetComponent<FlickController>();
        timercontroller = GameObject.Find("Time_txt").GetComponent<TimerController>();
        playerinputmanager = GameObject.Find("PlayerInputManager").GetComponent<PlayerInputManager>();
    }

    public GameObject GetPlayer(){
        return turnmanager.players[turnmanager.playerTurn];
    }

    public GameObject GetXPlayer(int player){
        return turnmanager.players[player];
    }

    public Rigidbody GetPlayerRb(){
        return GetPlayer().GetComponent<Rigidbody>();
    }

    public Transform GetPlayerTransform(){
        return GetPlayer().transform;
    }

    public Vector3 GetPlayerPos(){
        return GetPlayer().transform.position;
    }

    public PlayerCollisionController GetPlayerCollisionController(){
        return GetPlayer().GetComponent<PlayerCollisionController>();
    }

    

    public CharacterClass GetCharacterClass(){
        return GetPlayer().GetComponent<CharacterClass>();
    }

    public void FlickVisuals(){
        StartCoroutine(flickcontroller.Flicked());
        timercontroller.PauseTimer();
    }

    public void Reset(){
        shootcontroller.Reset();
        playerinputmanager.Reset();
        timercontroller.ResetTimer();
    }

    public void NextTurn(){
        turnmanager.NextTurn();
    }

    
}
