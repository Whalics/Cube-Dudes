using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterClass : MonoBehaviour
{
    public int maxHealth;
    public int health;
    [SerializeField] int _maxFlicks;
    [SerializeField] int _flicks;
    public int damage;

    public Character character;
    
    public TMP_Text nameText;
    public TMP_Text descriptionText;
    public Image cardImage;
    public Material charMaterial;
    public MeshRenderer[] meshRenderer;
    

    [SerializeField] PlayerHealthController playerhealthcontroller;

    void Awake(){
        playerhealthcontroller = gameObject.GetComponent<PlayerHealthController>();
    }

    void Start()
    {
        //nameText.text = character.name;
        //descriptionText.text = character.description;
        maxHealth = character.health;
        health = maxHealth;
        playerhealthcontroller.SetMaxHealth(maxHealth);
        _maxFlicks = character.flicks;
        _flicks = _maxFlicks;
        damage = character.damage;

        
        for(int i = 0; i < meshRenderer.Length; i++){
            meshRenderer[i].material = character.meshMaterial;
        }

        AssignAbility();
    }

    public void DecreaseFlicks(){
        _flicks--;
    }

    public void ResetFlicks(){
        _flicks = _maxFlicks;
    }

    public int ReturnFlicks(){
        return _flicks;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public virtual void Attack(){
        Debug.Log("The basic foundation for ability was used");
    }

    public void AssignAbility(){

        if(character.myCharacter == Character.CharacterType.Brick)
            gameObject.AddComponent<BrickAbility>();

        if(character.myCharacter == Character.CharacterType.Ninja)
            gameObject.AddComponent<NinjaAbility>();

        if(character.myCharacter == Character.CharacterType.Zombie)
            gameObject.AddComponent<ZombieAbility>();
        }
}
