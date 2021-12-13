using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;
    public HealthBar healthBar;
    

    [SerializeField] private GameObject PanelWin;
    Grid grid;




    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHeath(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
       
        if(currentHealth <= 0)
           {
            Destroy(gameObject);
            
            PanelWin.SetActive(true);
        }

        
    }

    public void TakeDamage(int damage)
    {
         if(gameObject.name.Equals("Boss"))
         {
            Debug.Log("take damage");
            Debug.Log("health:" + currentHealth + "left");
            currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
             
         }   
        
    }
}
