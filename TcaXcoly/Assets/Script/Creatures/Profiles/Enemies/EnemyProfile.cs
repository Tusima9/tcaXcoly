using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyProfile", menuName = "Creature/EnemyProfiles")]
public class EnemyProfile : Profile
{
    [Header("Enemy")]
    public int statspoints = 5;
}
