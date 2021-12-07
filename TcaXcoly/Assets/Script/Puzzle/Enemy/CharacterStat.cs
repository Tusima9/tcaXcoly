using UnityEngine;

public class CharacterStat : MonoBehaviour
{


    public string elements;
    public float MaximumHitPoints = 100f;
    public float CurrentHitPoints { get; private set; }
   
  
    public Stat armor;
    public Stat damage;

    void Awake()
    {
        CurrentHitPoints = MaximumHitPoints;
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(20f);
        }  
    }

    public void TakeDamage(float damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, float.MaxValue);

        CurrentHitPoints -= damage;
        Debug.Log(transform.name + "takes" + damage + "damage.");

        if (CurrentHitPoints <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        // character die in a way 

        Debug.Log(transform.name + "died.");
    }
}
