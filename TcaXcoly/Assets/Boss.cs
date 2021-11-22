using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public static float healthAmount;

    Grid grid;

   


    // Start is called before the first frame update
    void Start()
    {
        healthAmount = 10;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(healthAmount <= 0)
           {
            Destroy(gameObject);
            
           }

        
    }

    public void Damage()
    {
        
        

         if(gameObject.name.Equals("Boss"))
         {
            Debug.Log("take damage");
            Debug.Log("health:" + healthAmount + "left");
            healthAmount -= 0.1f;
             
         }
            
        
    }
}
