using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReorientPlayer : MonoBehaviour
{
    TurnManager turnmanager;
    Quaternion straight = Quaternion.identity;
    Camera cam;
    public bool reorient;
    Vector3 up;
    Vector3 targetposition;
    public LayerMask L_Ground;
            Vector3 hitpos;
    void Start(){
        cam = Camera.main;
        turnmanager = gameObject.GetComponent<TurnManager>();
    }
    
    public void SetUp(){
        up = new Vector3(turnmanager.players[turnmanager.playerTurn].transform.position.x,turnmanager.players[turnmanager.playerTurn].transform.position.y+1,turnmanager.players[turnmanager.playerTurn].transform.position.z);
        targetposition = new Vector3(0,cam.transform.position.y,0);
        //turnmanager.players[turnmanager.playerTurn].transform.position = Vector3.Lerp(turnmanager.players[turnmanager.playerTurn].transform.position,up, 0.1f);
    }
    public void Reorient(){

        for(int i = 0; i < turnmanager.players.Length; i++){
            RaycastHit hit;
            Debug.DrawRay(turnmanager.players[i].transform.position+Vector3.up, Vector3.down*20, Color.red,20f);
            if(Physics.Raycast(turnmanager.players[i].transform.position+Vector3.up,Vector3.down, out hit, 20,L_Ground)){
                hitpos = hit.point;
                up = new Vector3(turnmanager.players[i].transform.position.x,hitpos.y+0.3f,turnmanager.players[i].transform.position.z);
            }
            // Renderer rend =  turnmanager.players[i].gameObject.GetComponent<Renderer>();
            // float bottom = rend.bounds.extents.magnitude/2;
            
            turnmanager.players[i].transform.position = up;
            turnmanager.players[i].transform.LookAt(targetposition);
        }
        //turnmanager.players[turnmanager.playerTurn].transform.position = up;
        //turnmanager.players[turnmanager.playerTurn].transform.position = Vector3.Lerp(turnmanager.players[turnmanager.playerTurn].transform.position,up, 0.05f);
        //Quaternion lookOnLook = Quaternion.LookRotation(targetposition);
        //turnmanager.players[turnmanager.playerTurn].transform.rotation = Quaternion.Slerp(turnmanager.players[turnmanager.playerTurn].transform.rotation, lookOnLook, 0.05f);
        turnmanager.players[turnmanager.playerTurn].transform.LookAt(targetposition);
        //if(turnmanager.players[turnmanager.playerTurn].transform.position == up){
         //   reorient = false;
        //}
    }

    void Update(){
        if(reorient){
            Reorient();
        }
    }
    
}
