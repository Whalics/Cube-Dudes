using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    public new string name;
    public enum CharacterType {Bob, Brick, Chef, Hypno, Ninja, Spy, Vampire, Zombie};
    public CharacterType myCharacter;
    public string description;
    public Material meshMaterial;
    public Sprite characterCardArtwork;

    public int characterIndex;
    public int health;
    public int flicks;
    public int damage;
}
