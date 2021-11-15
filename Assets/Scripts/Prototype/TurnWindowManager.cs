using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TurnWindowManager : MonoBehaviour
{
    [Tooltip("The text that displays which player's turn it currently is.")]
    [SerializeField] TMP_Text playerTurn;
    [Tooltip("The slider that displays turn continue progress when the 'A' button is held.")]
    [SerializeField] Slider holdSlider;
    [Tooltip("The image portrait of the player who turn it is, pulled from the player's character class.")]
    [SerializeField] Image portrait;
    [SerializeField] GameManager gamemanager;
    void Awake()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnEnable(){
        UpdateWindow();
        UpdateImage();
    }

    void Update(){
    }

    void UpdateWindow(){
        if(gamemanager.GetTurn()+1 != gamemanager.GetPlayerCount())
        playerTurn.text = "Player " + (gamemanager.GetTurn()+2).ToString() + "'s Turn";
        else
        playerTurn.text = "Player 1's Turn";
    }

    void UpdateImage(){
        if(gamemanager.GetTurn()+1 != gamemanager.GetPlayerCount())
        portrait.sprite = gamemanager.GetXPlayer(gamemanager.GetTurn()+1).GetComponent<CharacterClass>().portrait;
        else
        portrait.sprite = gamemanager.GetXPlayer(0).GetComponent<CharacterClass>().portrait;
    }
}
