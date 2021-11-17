using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AbilityCardDisplay : MonoBehaviour
{

    public Character character;
    public TMP_Text nameText;
    //public TMP_Text descriptionText;
    public TMP_Text healthText;
    public TMP_Text damageText;
    public TMP_Text flicksText;
    public TMP_Text cooldownText;
    public Image cardArt;
    

     
    void Start(){
    }

    public void UpdateInfo(){
        //descriptionText.text = character.description;
        nameText.text = character.name.ToString();
        healthText.text = "Health: " + character.health.ToString();
        cooldownText.text = "Ability Cooldown: " + character.cooldown.ToString();
        damageText.text = "Damage: " + character.damage.ToString();
        flicksText.text = "Flicks: " + character.flicks.ToString();
        cardArt.sprite = character.portrait;

    }
}
