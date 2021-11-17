using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public GameObject[] players;
    public int playerTurn = 0;
    public bool flickOver;

    CameraManager cameramanager;
    PlayerCollisionController playercollisioncontroller;
    FlickController flickcontroller; 
    ReorientCharacter reorientcharacter;
    CharacterClass characterclass;
    TimerController timercontroller;

    public GameObject TurnWindowCanvas;

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
        // if(timercontroller.GetTurnTimer() <= 0){
        //     StartCoroutine(EndTurn());
        // }
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
    // public IEnumerator EndTurn(){
    //     flickOver = true;
        
    //     yield return new WaitForSeconds(1f);
    //     //reorientplayer.SetUp();
    //     for(int i = 0; i < players.Length; i++){
    //          reorientcharacter = gamemanager.GetXPlayer(i).GetComponent<ReorientCharacter>();
    //          reorientcharacter.SetVariables();
    //          reorientcharacter.reorienting = true;
    //          yield return new WaitForSeconds(Random.Range(0.1f,0.3f));
    //     }
    //     yield return new WaitForSeconds(1.5f);
    //     //StartCoroutine(NextTurn());
    //     if(characterclass.ReturnFlicks() <= 1){
    //         TurnWindow();
    //         timercontroller.ResetTimer();
    //     }
    //     else StartCoroutine(NextTurn());
    //     gamemanager.Reset();
    //     flickOver = false;
    // }

    public IEnumerator EndFlick(){
        flickOver = true;
        yield return new WaitForSeconds(1f);
        //reorient players
        for(int i = 0; i < players.Length; i++){
            reorientcharacter = gamemanager.GetXPlayer(i).GetComponent<ReorientCharacter>();
            reorientcharacter.SetVariables();
            reorientcharacter.reorienting = true;
            yield return new WaitForSeconds(Random.Range(0.1f,0.3f));
        }
        yield return new WaitForSeconds(1.5f);
        if(characterclass.ReturnFlicks() <= 1){
            TurnWindow();
            gamemanager.ResetTurn(); //resets shoot controller, input controller, and timer
        }
        else{
            StartCoroutine(NextFlick()); 
            gamemanager.ResetFlick(); //resets shoot controller, input controller, resumes timer
        }
        flickOver = false;
    }

    public IEnumerator EndTurn(){ //this is for the timer running out. regardless of flicks remaining, the turn will end.
        //gamemanager.HideDeck();
        TurnWindow();
        gamemanager.ResetTurn(); //resets shoot controller, input controller, and timer
        yield break;
    }

    public IEnumerator NextFlick(){
        characterclass = gamemanager.GetCharacterClass();
        characterclass.DecreaseFlicks();
        playercollisioncontroller.ResetCollision();
        cameramanager.MoveToPlayer();
        yield break;
    }
    
    public IEnumerator NextTurn(){
        HideTurnWindow();
        gamemanager.HideDeck();
        gamemanager.ShowDeck();
        characterclass = gamemanager.GetCharacterClass();
        characterclass.ResetFlicks();

        playercollisioncontroller.ResetCollision();
        playercollisioncontroller.myTurn = false;

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

    public void TurnWindow(){
        gamemanager.DisableControls();
        TurnWindowCanvas.SetActive(true);
    }

    public void HideTurnWindow(){
        gamemanager.EnableControls();
        TurnWindowCanvas.SetActive(false);
    }



}
