using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDeath : MonoBehaviour
{
    public bool dead = false;
    [SerializeField] GameObject[] bodyParts;
    [SerializeField] PlayerCollisionController playercollisioncontroller;
    [SerializeField] GameManager gamemanager;
    
    void Start(){
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    public void Die(){
        dead = true;
        PlayerCollisionController playercollisioncontroller = gamemanager.GetPlayerCollisionController();
        Destroy(GetComponent(typeof(Rigidbody)));
        for(int i = 0; i < bodyParts.Length; i++){
            
            Rigidbody bdpt = bodyParts[i].AddComponent<Rigidbody>() as Rigidbody;
            playercollisioncontroller.TransferVelocity(bdpt,2f,1.5f);
        }
    }
}
