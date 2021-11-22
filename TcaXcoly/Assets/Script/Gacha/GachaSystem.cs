using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GachaSystem : MonoBehaviour
{

    [SerializeField]
    private Text  _text;
    [SerializeField]
    private GameObject _gachaManager;
    CardManager cardManager;

    [Range(0.0f, 100)]
    public float RareChance;
    [Range(0.0f, 100)]
    public float SRareChance;
    [Range(0.0f, 100)]
    public float SSRareChance;
    

    public void NgeGacha()
    {
        float r = Random.Range(0.0f, 100.1f);
        Debug.Log(r + "%");
        if (r>= RareChance)
        {
            RareCard();
        }
        else if (r>= SRareChance)
        {
            SRareCard();
        }
        else if (r >= SSRareChance)
        {
            SSRareCard();
        }
        
    }

    public void NgeGacha10()
    {
        
        for (int i = 0; i < 10; i++)
        {
        float r = Random.Range(0.0f, 100.1f);
       // Debug.Log(r + "%");
            if (r >= RareChance)
            {
                RareCard();
            }
            else if (r >= SRareChance)
            {
                SRareCard();
            }
            else if (r >= SSRareChance)
            {
                SSRareCard();
            }

        }
       
            
    }
    
    public void RareCard() {
        Debug.Log("draw rare!");

    }
    public void SRareCard()
    {
        Debug.Log("draw Srare!");

    }
    public void SSRareCard()
    {
        Debug.Log("draw SSrare!");
    }
    
    
}
