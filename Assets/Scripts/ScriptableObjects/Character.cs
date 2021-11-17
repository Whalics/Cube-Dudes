using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    [Tooltip("The character's name")]
    public new string name;

    public enum CharacterType {Bob, Brick, Chef, Hypno, Ninja, Spy, Vampire, Zombie};
    [Tooltip("The character's enum, acting like a tag to differentiate character attacks.")]
    public CharacterType myCharacter;
    [Tooltip("A brief description of the character, subject to change.")]
    public string description;
    [Tooltip("The material that will be placed on the player prefab.")]
    public Material meshMaterial;
    [Tooltip("The artwork that will appear on the character's ability card.")]
    public Sprite characterCardArtwork;

    [Tooltip("This character's number index, corresponding to it's alphabetical position amongst other characters.")]
    public int characterIndex;
    [Tooltip("The maximum amount of health this character has.")]
    public int health;
    [Tooltip("The number of flicks this character has per turn.")]
    public int flicks;
    [Tooltip("The amount of damage this character deals.")]
    public int damage;
    [Tooltip("The cooldown of this character's ability")]
    public int cooldown;
    [Tooltip("The image the appears on the turn window between turns.")]
    public Sprite portrait;
}
