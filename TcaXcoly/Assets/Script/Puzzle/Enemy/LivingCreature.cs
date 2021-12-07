using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

public class LivingCreature : MonoBehaviour
{
      
    
    public int CurrentHitPoints { get; set; } 
     public int MaximumHitPoints { get; set; }
    // Start is called before the first frame update
    

    public LivingCreature(int currentHitPoints, int maximumHitPoints)
    {
        CurrentHitPoints = currentHitPoints;
        MaximumHitPoints = maximumHitPoints;
    }

    
}
