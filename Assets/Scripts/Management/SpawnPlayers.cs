using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject[] spawnEmpties;
    public GameObject blankPlayerPrefab;
    //public GameObject[] players;
    TurnManager turnmanager;
    // Start is called before the first frame update
    void Start()
    {
        turnmanager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        //spawnEmpties = new GameObject[PlayerManagerSingleton.Instance.playerCount];
        turnmanager.players = new GameObject[PlayerManagerSingleton.Instance.playerCount];
        // turnmanager.players = new GameObject[PlayerManagerSingleton.Instance.playerCount]
        for(int i = 0; i<PlayerManagerSingleton.Instance.playerCount; i++){
            //spawnEmpties[i] = GameObject.Find("Spawn"+i);
            turnmanager.players[i] = Instantiate(blankPlayerPrefab,spawnEmpties[i].transform.position,Quaternion.identity);
           
            CharacterClass characterclass = turnmanager.players[i].GetComponent<CharacterClass>();
            characterclass.character = PlayerManagerSingleton.Instance.playerCharacters[i];
        }
        //PlayerManagerSingleton.Instance.player
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
