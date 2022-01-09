using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
    CharacterBase _base;
    int level;

    public Characters(CharacterBase pbase, int plevel)
    {
        _base = pbase;
        level = plevel;
    }

    public int Attack
    {
        get { return Mathf.FloorToInt((_base.Attack * level) / 100) + 2; }
    }
    public int Defense
    {
        get { return Mathf.FloorToInt((_base.Defense * level) / 100) + 2; }
    }
    public int SpecialAttack
    {
        get { return Mathf.FloorToInt((_base.SpecialAttack * level) / 100) + 2; }
    }
    public int MaxHP
    {
        get { return Mathf.FloorToInt((_base.MaxHP * level) / 100) + 10; }
    }
}
