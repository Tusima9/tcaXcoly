using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerProfile", menuName ="Creature/PlayerCharacters")]
public class PlayerProfile : Profile
{
    [Header("Player")]
    public Statistic mana;
    public Statistic attack;
    public Statistic defense;
}
