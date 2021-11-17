using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterClass : MonoBehaviour
{
    [Tooltip("The maximum amount of health this character has.")]
    public int maxHealth;
    [Tooltip("The current amount of health this character has.")]
    public int health;
    [Tooltip("The maximum number of flicks this character has per turn.")]
    [SerializeField] int _maxFlicks;
    [Tooltip("The number of flicks this character has left this turn.")]
    [SerializeField] int _flicks;
    [Tooltip("The amount of damage this character deals")]
    public int damage;
    [Tooltip("The cooldown of this character's ability")]
    public int coolDown;
    [Tooltip("The scriptable object that defines this character.")]
    public Character character;

    [Tooltip("The character's name.")]
    public TMP_Text nameText;
    [Tooltip("A brief description of the character, subject to change.")]
    public TMP_Text descriptionText;
     [Tooltip("The artwork that will appear on the character's ability card")]
    public Image cardImage;
    [Tooltip("The material that will be placed on the player prefab.")]
    public Material charMaterial;
    [Tooltip("The player prefab's material renderer, set as an array for each part of the character's body.")]
    public MeshRenderer[] meshRenderer;
    [Tooltip("The image the appears on the turn window between turns.")]
    public Sprite portrait;

    [SerializeField] PlayerHealthController playerhealthcontroller;

    void Awake(){
        playerhealthcontroller = gameObject.GetComponent<PlayerHealthController>();
    }

    void Start()
    {
        //nameText.text = character.name;
        //descriptionText.text = character.description;
        maxHealth = character.health;
        coolDown = character.cooldown;
        health = maxHealth;
        playerhealthcontroller.SetMaxHealth(maxHealth);
        _maxFlicks = character.flicks;
        _flicks = _maxFlicks;
        damage = character.damage;
        portrait = character.portrait;
        
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
