using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TurnWindowManager : MonoBehaviour
{
    [SerializeField] TMP_Text playerTurn;
    [SerializeField] Image playerImage;
    [SerializeField] Slider holdSlider;

    [SerializeField] GameManager gamemanager;
    void Awake()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start(){
        UpdateWindow();
    }

    void Update()
    {
        
    }

    void UpdateWindow(){
        playerTurn.text = "Player " + (gamemanager.GetTurn()+2).ToString() + "'s Turn";
    }
}
