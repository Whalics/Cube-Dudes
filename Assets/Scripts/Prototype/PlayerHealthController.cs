using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int maxHealth;
    [SerializeField] Slider healthSlider;

    void Start(){
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
        }
        else if (health <= dmg)
        Die();

        healthSlider.value = health;
    }
    
    public void GainHealth(int heal){
        health+=heal;
        healthSlider.value = health;
    }

    public void Die(){
        this.gameObject.SetActive(false);
    }
}
