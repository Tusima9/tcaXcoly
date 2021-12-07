using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

public class Monster : MonoBehaviour
{

    public int ID { get; set; }
    public string Name{ get; set;}
    public int  MaximumDamage { get; set; }
    //public int RewardExpreriencePoints { get; set; }
    //public int RewardGold { get; set; }

    //public List<LootItem> LootTable { get; set; }

    public Monster(int id, string name, int maximumDamage)
    {
        ID = id;
        Name = name;
        MaximumDamage = maximumDamage;

    }
}
