using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character List Database", menuName = "New Character List Database/Character Database")]
public class Character_Database : ScriptableObject
{
    public List<CharacterBase> allCharacters;
}
