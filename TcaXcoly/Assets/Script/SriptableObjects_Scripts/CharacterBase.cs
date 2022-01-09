using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="Character", menuName ="Character/Create new Character")]
public class CharacterBase : ScriptableObject
{
    public string memberID;

    [SerializeField] string charcterName;
    
    [TextArea] 
    [SerializeField] string description;

    [SerializeField] Sprite characterSprite;

    [SerializeField] CharacterType type;

    //Base Stats
    [SerializeField] int maxHP;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int specialAttack;

    public string Name
    {
        get { return charcterName; }
    }
    public string Description
    {
        get { return description; }
    }
    public Sprite CharacterSprite
    {
        get { return characterSprite; }
    }
    public CharacterType Type
    {
        get { return type; }
    }
    public int MaxHP
    {
        get { return maxHP; }
    }
    public int Attack
    {
        get { return attack; }
    }
    public int Defense
    {
        get { return defense; }
    }
    public int SpecialAttack
    {
        get { return specialAttack; }
    }
}

public enum CharacterType{
    None,
    Light,
    Water,
    Fire,
    Poison,
    Wind
}
