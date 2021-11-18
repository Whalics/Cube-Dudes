using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int maxHealth;
    [SerializeField] Slider healthSlider;
    [SerializeField] CharacterDeath characterdeath;
    
    [SerializeField] Rigidbody playerRb;
    void Start(){
        characterdeath = this.gameObject.GetComponent<CharacterDeath>();
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
    } 

    public void SetMaxHealth(int hlth){
        maxHealth = hlth;
    }


    public void TakeDamage(int dmg){
        if(health > dmg){
            health -= dmg;
            healthSlider.value = health;
        }
        else if (health <= dmg){
            healthSlider.value = 0;
            characterdeath.Die();
        }

       
    }
    
    public void GainHealth(int heal){
        health+=heal;
        healthSlider.value = health;
    }

    
}
