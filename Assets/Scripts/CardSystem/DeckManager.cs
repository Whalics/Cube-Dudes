using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
    
    
    public GameObject currentDeckPos;
    public GameObject hiddenDecksPos;
    public GameObject cardPrefab;
    
    public Card[] cardsIndex;

    public GameObject playerDeck1;
    public GameObject playerDeck2;
    public GameObject playerDeck3;
    public GameObject playerDeck4;

    public GameObject[] player1Cards;
    public GameObject[] player2Cards;
    public GameObject[] player3Cards;
    public GameObject[] player4Cards;

    public GameObject[] abilityBTNS;
    
    GameManager gamemanager;
    public Navigation buttonNavigation;
    public Button leftNav;
    public Button rightNav;
    public Button abilityButton;
    void Awake(){
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void Start(){
        if(gamemanager.GetPlayerCount() == 2){
            PopulateDeck(player1Cards);
            SetNavigation(player1Cards);
            PopulateDeck(player2Cards);
            SetNavigation(player2Cards);
        }

        if(gamemanager.GetPlayerCount() == 3){
            PopulateDeck(player1Cards);
            SetNavigation(player1Cards);
            PopulateDeck(player2Cards);
            SetNavigation(player2Cards);
            PopulateDeck(player3Cards);
            SetNavigation(player3Cards);
        }

        if(gamemanager.GetPlayerCount() == 4){
            PopulateDeck(player1Cards);
            SetNavigation(player1Cards);
            PopulateDeck(player2Cards);
            SetNavigation(player2Cards);
            PopulateDeck(player3Cards);
            SetNavigation(player3Cards);
            PopulateDeck(player4Cards);
            SetNavigation(player4Cards);
        }
        DisplayDeck();
        
    }
    
    void PopulateDeck(GameObject[] deck){
        for(int i = 1; i < 6; i++){
            deck[i].GetComponentInChildren<CardDisplay>().card = cardsIndex[Random.Range(0,cardsIndex.Length)];
            deck[i].GetComponentInChildren<CardDisplay>().UpdateInfo();
        }
        
    }
    void SetAbilityNavigation(){
        
    }

    void SetNavigation(GameObject[] deck){
        for(int i = 0; i < 6; i++){
            if(i < 5)
            rightNav = deck[i+1].GetComponentInChildren<Button>();
            
            if(i > 0)
            leftNav = deck[i-1].GetComponentInChildren<Button>();
            
            if(i==5){
                rightNav = deck[0].GetComponentInChildren<Button>();
            }
            if(i == 0){
                leftNav = deck[5].GetComponentInChildren<Button>();
            }

            buttonNavigation.selectOnRight = rightNav;
            buttonNavigation.selectOnLeft = leftNav;
            //abilityBTNS[]
            //abilityButton.navigation.selectOnLeft = deck[4].GetComponentInChildren<Button>();;

            deck[i].GetComponentInChildren<Button>().navigation = buttonNavigation;
            
        }
    }


    public void DisplayDeck(){
        if(gamemanager.GetTurn() == 0){
            playerDeck1.transform.position = currentDeckPos.transform.position;
        }
        if(gamemanager.GetTurn() == 1){
            playerDeck2.transform.position = currentDeckPos.transform.position;
        }
        if(gamemanager.GetTurn() == 2){
            playerDeck3.transform.position = currentDeckPos.transform.position;
        }
        if(gamemanager.GetTurn() == 3){
            playerDeck4.transform.position = currentDeckPos.transform.position;
        }
    }
    
    public void HideDecks(){
        if(gamemanager.GetTurn() == 0){
            playerDeck2.transform.position = hiddenDecksPos.transform.position;
            playerDeck3.transform.position = hiddenDecksPos.transform.position;
            playerDeck4.transform.position = hiddenDecksPos.transform.position;
        }

        if(gamemanager.GetTurn() == 1){
            playerDeck1.transform.position = hiddenDecksPos.transform.position;
            playerDeck3.transform.position = hiddenDecksPos.transform.position;
            playerDeck4.transform.position = hiddenDecksPos.transform.position;
        }

        if(gamemanager.GetTurn() == 2){
            playerDeck1.transform.position = hiddenDecksPos.transform.position;
            playerDeck2.transform.position = hiddenDecksPos.transform.position;
            playerDeck4.transform.position = hiddenDecksPos.transform.position;
        }

        if(gamemanager.GetTurn() == 3){
            playerDeck1.transform.position = hiddenDecksPos.transform.position;
            playerDeck2.transform.position = hiddenDecksPos.transform.position;
            playerDeck3.transform.position = hiddenDecksPos.transform.position;
        }
    }
}
