using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{


    TurnManager turnmanager;
    ShootController shootcontroller;
    CharacterClass characterclass;
    [SerializeField] Rigidbody _rb;
    [SerializeField] Rigidbody collisionRb;
    public bool hasCollided;
    public bool myTurn;
    public bool inMotion;
    // Start is called before the first frame update
    void Start()
    {
        turnmanager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        shootcontroller = GameObject.Find("ShootController").GetComponent<ShootController>();
        characterclass = gameObject.GetComponent<CharacterClass>();
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_rb.velocity.magnitude < 0.01f){
            if(collisionRb != null){
                if(collisionRb.velocity.magnitude < 0.01){
                    if(shootcontroller.isShot && hasCollided){
                        if(!turnmanager.flickOver){
                            ClearCollisionRb();
                            StartCoroutine(turnmanager.EndFlick());
                        }
                    }
                }
            }
        }

        if(inMotion && _rb.velocity.magnitude < 0.01f && !hasCollided && shootcontroller.isShot){
            if(!turnmanager.flickOver){
            StartCoroutine(turnmanager.EndFlick());
                
            }
        }
    }

    public void OnCollisionEnter(Collision collision){
        if(shootcontroller.isShot){
            if(myTurn && collision.gameObject.tag != "Ground"){
                if(!hasCollided){
                    hasCollided = true;
                    collision.gameObject.GetComponent<PlayerHealthController>().TakeDamage(characterclass.damage);
                }
                collisionRb = collision.gameObject.GetComponent<Rigidbody>();
                TransferVelocity(collisionRb, 1.2f, 2.5f);
            }
        }
    }

    public void TransferVelocity(Rigidbody crb, float mult, float reduce){
        
        crb.AddForce(_rb.velocity*mult, ForceMode.Impulse);
        _rb.velocity/=reduce;
    }

    public void ClearMotion(){
        if(collisionRb != null){
            collisionRb.velocity = Vector3.zero;
            collisionRb.angularVelocity = Vector3.zero;
        }
    }

    void ClearCollisionRb(){
        collisionRb = null;
    }
    
    public void MyTurn(){
        myTurn = true;
    }

    public IEnumerator InMotion(){
        yield return new WaitForSeconds(0.2f);
        inMotion = true;
    }
    
    public void ResetCollision(){
        hasCollided = false;
        inMotion = false;
    }
}
