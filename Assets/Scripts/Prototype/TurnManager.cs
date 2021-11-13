using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public GameObject[] players;
    public int playerTurn = 0;
    public bool turnOver;

    CameraManager cameramanager;
    PlayerCollisionController playercollisioncontroller;
    FlickController flickcontroller; 
    ReorientCharacter reorientcharacter;
    CharacterClass characterclass;
    TimerController timercontroller;

    GameManager gamemanager;
    void Start()
    {

        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        flickcontroller = GameObject.Find("Finger").GetComponent<FlickController>();
        timercontroller =  GameObject.Find("Time_txt").GetComponent<TimerController>();
        cameramanager = GameObject.Find("CameraRotator").GetComponent<CameraManager>();
        playercollisioncontroller = players[playerTurn].GetComponent<PlayerCollisionController>();
        
        characterclass = gamemanager.GetCharacterClass();

        playerTurn = 0;
        playercollisioncontroller.myTurn = true;
    }

    void Update()
    {
        if(timercontroller.GetTurnTimer() <= 0){
            StartCoroutine(endTurn());
        }
        //if(!shootcontroller.isShot)
        //SpinCameraAroundPlayer();
        //else
    }

    // void SpinCameraAroundPlayer(){
    //     spinOffset = Vector3.right * spinSpeed * Time.deltaTime;
    //     cam.transform.LookAt(players[playerTurn].transform);
    //     cam.transform.Translate(spinOffset);
    //     camRotation.y = cam.transform.rotation.y;
    // }
    public IEnumerator endTurn(){
        turnOver = true;
        yield return new WaitForSeconds(1f);
        //reorientplayer.SetUp();
        for(int i = 0; i < players.Length; i++){
             reorientcharacter = gamemanager.GetXPlayer(i).GetComponent<ReorientCharacter>();
             reorientcharacter.SetVariables();
             reorientcharacter.reorienting = true;
             yield return new WaitForSeconds(Random.Range(0.1f,0.3f));
        }
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(NextTurn());
        gamemanager.Reset();
        turnOver = false;
    }
    
    public IEnumerator NextTurn(){
        characterclass = gamemanager.GetCharacterClass();
        characterclass.DecreaseFlicks();
        if(characterclass.ReturnFlicks() > 0){
            playercollisioncontroller.hasCollided = false;
            playercollisioncontroller.inMotion = false;
            cameramanager.MoveToPlayer();
            yield break;
        }
        else{
            characterclass.ResetFlicks();
            playercollisioncontroller.hasCollided = false;
            playercollisioncontroller.myTurn = false;
            playercollisioncontroller.inMotion = false;
            if(playerTurn < players.Length-1){
                playerTurn++;
            }
            else{
                playerTurn = 0;
            }
            characterclass = gamemanager.GetCharacterClass();
            playercollisioncontroller = gamemanager.GetPlayerCollisionController();
            playercollisioncontroller.myTurn = true;
            cameramanager.MoveToPlayer();
            yield break;
        }
    }
}
