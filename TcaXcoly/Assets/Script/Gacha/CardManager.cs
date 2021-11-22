using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public Animator animator;
     public GameObject cardmanager;

    public enum Rarity
    {
        Common,Uncommon,Rare,MediumRare,SpecialRare,Lengendary
    }

    public List<Sprite> cardDatabase;
    public List<Sprite> cardCommon;
    public List<Sprite> cardUncommon;
    public List<Sprite> cardRare;
    public List<Sprite> cardMediumRare;
    public List<Sprite> cardSpecialRare;
    public List<Sprite> cardLengendary;

    public Image cardUI;

    public void CardSystem(Rarity r)
    {
        cardmanager.gameObject.SetActive(true);
        switch (r)
        {
            case Rarity.Common:
                Animation(cardCommon[Random.Range(0, cardCommon.Count)]);
                break;
            case Rarity.Uncommon:
                Animation(cardUncommon[Random.Range(0, cardUncommon.Count)]);
                break;
            case Rarity.Rare:
                Animation(cardRare[Random.Range(0, cardRare.Count)]);
                break;
            case Rarity.MediumRare:
                Animation(cardMediumRare[Random.Range(0, cardMediumRare.Count)]);
                break;
            case Rarity.SpecialRare:
                Animation(cardSpecialRare[Random.Range(0, cardSpecialRare.Count)]);
                break;
            case Rarity.Lengendary:
                Animation(cardLengendary[Random.Range(0, cardLengendary.Count)]);
                break;
        }
    }

    public void Animation(Sprite s)
    {
        
        animator.SetTrigger("Gacha");
        cardUI.sprite = s;
        
    }
}
