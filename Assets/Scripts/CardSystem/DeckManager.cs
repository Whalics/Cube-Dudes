using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    GameManager gamemanager;

    void Awake(){
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void Start(){
        if(gamemanager.GetPlayerCount() == 2){
            PopulateDeck(player1Cards);
            PopulateDeck(player2Cards);
        }

        if(gamemanager.GetPlayerCount() == 3){
            PopulateDeck(player1Cards);
            PopulateDeck(player2Cards);
            PopulateDeck(player3Cards);
        }

        if(gamemanager.GetPlayerCount() == 4){
            PopulateDeck(player1Cards);
            PopulateDeck(player2Cards);
            PopulateDeck(player3Cards);
            PopulateDeck(player4Cards);
        }
        DisplayDeck();
    }

    void PopulateDeck(GameObject[] deck){
        for(int i = 0; i < 5; i++){
            deck[i].GetComponentInChildren<CardDisplay>().card = cardsIndex[Random.Range(0,cardsIndex.Length)];
            deck[i].GetComponentInChildren<CardDisplay>().UpdateInfo();
        }
    }

    // public void CreateCards(){
    //     for(int i = 0; i < 5; i++){
    //         cards[i] = Instantiate(cardPrefab,Vector3.zero,Quaternion.identity);
    //         cards[i].transform.SetParent(deckSpace.transform, false);
    //     }
    // }

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

    //      for(int i = 0; i < 5; i++){
    //         if(player == 0)
    //         cards[i].GetComponentInChildren<CardDisplay>().card = playerDeck2[i];

    //         if(player == 1)
    //         cards[i].GetComponentInChildren<CardDisplay>().card = playerDeck3[i];

    //         if(player == 2)
    //         cards[i].GetComponentInChildren<CardDisplay>().card = playerDeck4[i];

    //         if(player == 3)
    //         cards[i].GetComponentInChildren<CardDisplay>().card = playerDeck1[i];
    //      }
    
}
