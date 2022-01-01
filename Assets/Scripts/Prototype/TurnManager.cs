using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public GameObject[] players;
    public int deadPlayers = 0;
    public int playerTurn = 0;
    public bool flickOver;

    CameraManager cameramanager;
    PlayerCollisionController playercollisioncontroller;
    FlickController flickcontroller; 
    ReorientCharacter reorientcharacter;
    CharacterClass characterclass;
    TimerController timercontroller;

    public GameObject TurnWindowCanvas;
    public TMP_Text winText;

    GameManager gamemanager;
    void Awake()
    {

        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        flickcontroller = GameObject.Find("Finger").GetComponent<FlickController>();
        timercontroller =  GameObject.Find("Time_txt").GetComponent<TimerController>();
        cameramanager = GameObject.Find("CameraRotator").GetComponent<CameraManager>();
        playercollisioncontroller = players[playerTurn].GetComponent<PlayerCollisionController>();
        
       
    }

    void Start(){
        characterclass = gamemanager.GetCharacterClass();
        playerTurn = 0;
        playercollisioncontroller.myTurn = true;
        //dead = new bool[players.Length];
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
            if(!gamemanager.XPlayerDead(i)){
                reorientcharacter = gamemanager.GetXPlayer(i).GetComponent<ReorientCharacter>();
                reorientcharacter.SetVariables();
                reorientcharacter.reorienting = true;
                yield return new WaitForSeconds(Random.Range(0.1f,0.3f));
            }   
        }
        yield return new WaitForSeconds(1.5f);
        gamemanager.ForceSliderOut();
        if(characterclass.ReturnFlicks() == 0){
            characterclass = gamemanager.GetCharacterClass();
            characterclass.ResetFlicks();

            playercollisioncontroller.ResetCollision();
            playercollisioncontroller.myTurn = false;

            SetNextPlayersTurn();
            if(deadPlayers != players.Length-1){
                TurnWindow();
            }
            gamemanager.ResetTurn(); //resets shoot controller, input controller, and timer
        }
        else{
            StartCoroutine(NextFlick()); 
            gamemanager.ResetFlick(); //resets shoot controller, input controller, resumes timer
        }
        flickOver = false;
    }

    public IEnumerator EndTurn(){ //this is for the timer running out. regardless of flicks remaining, the turn will end.
        gamemanager.ResetTurn(); //resets shoot controller, input controller, and timer
        gamemanager.ResetFlick();
        // if(deadPlayers != players.Length-1){
        //     TurnWindow(); 
        // }
        yield break;
    }

    public IEnumerator NextFlick(){
        characterclass = gamemanager.GetCharacterClass();
        playercollisioncontroller.ResetCollision();
        cameramanager.MoveToPlayer();
        yield break;
    }
    
    public IEnumerator NextTurn(){
        HideTurnWindow();
        
        

        gamemanager.HideDeck();
        gamemanager.ShowDeck();
            
        characterclass = gamemanager.GetCharacterClass();
        playercollisioncontroller = gamemanager.GetPlayerCollisionController();
        playercollisioncontroller.myTurn = true;

        cameramanager.MoveToPlayer();
        yield break;
        
    }

    public void TurnWindow(){
        gamemanager.DisableControls();
        TurnWindowCanvas.SetActive(true);
        gamemanager.UnlockMenu();
    }

    public void HideTurnWindow(){
        gamemanager.EnableControls();
        TurnWindowCanvas.SetActive(false);
    }

    public void SetNextPlayersTurn(){
        deadPlayers = 0;
        for(int i = 0; i < players.Length; i++){
                if(gamemanager.XPlayerDead(i)){
                    deadPlayers++;
                    if(deadPlayers == players.Length-1){
                        if(gamemanager.GetTurn() != gamemanager.GetPlayerCount())
                            winText.text = "Player " + (gamemanager.GetTurn()+1).ToString() + " Wins!";
                        else
                            winText.text = "Player 1 Wins!";
                    }
                }
            }
        do{
            if(playerTurn < players.Length-1){
                
                
                playerTurn++;
            }
            else if(playerTurn == players.Length-1){
                playerTurn = 0;
            }

            
        }
        while(gamemanager.PlayerDead());

        
    }
}
