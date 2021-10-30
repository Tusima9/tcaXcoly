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

    [Range(0.0f, 100)]
    public float CommonChance;
    [Range(0.0f, 100)]
    public float UnCommonChance;
    [Range(0.0f, 100)]
    public float RareChance;
    [Range(0.0f, 100)]
    public float MediumRareChance;
    [Range(0.0f, 100)]
    public float SpecialChance;
    [Range(0.0f, 100)]
    public float LegendaryChance;

    public void NgeGacha()
    {
        float r = Random.Range(0.0f, 100.1f);

        if(r>= CommonChance)
        {
            CommonCard();
        }
        else if (r>= UnCommonChance)
        {
            UnCommonCard();
        }
        else if (r >= RareChance)
        {
            RareCard();
        }
        else if (r >= MediumRareChance)
        {
            MediumCard();
        }
        else if (r >= SpecialChance)
        {
            SpecialCard();
        }
        else if (r >= LegendaryChance)
        {
            LegendaryCard();
        }
    }
    public void CommonCard()
    {
        Debug.Log("draw Common!");
    }
    public void UnCommonCard()
    {
        Debug.Log("draw uncommon!");
    }
    public void RareCard()
    {
        Debug.Log("draw rare!");
    }
    public void MediumCard()
    {
        Debug.Log("draw medium!");
    }
    public void SpecialCard()
    {
        Debug.Log("draw special!");
    }
    public void LegendaryCard()
    {
        Debug.Log("draw legendary!");
    }
}
