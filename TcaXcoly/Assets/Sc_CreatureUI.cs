using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;

public class Sc_CreatureUI : MonoBehaviour
{
    [Serializable]
    private class StatInfo
    {
        public StatType thisStat;
        public Text statValueText;
        public Slider StatBar;

        public void UpdateDisplay(Sc_Creature creature)
        {
            statValueText.text = creature.GetState(thisStat).Value + "/" + creature.GetState(thisStat).MaxValue;
            if (StatBar != null)
            {
                StatBar.maxValue = creature.GetState(thisStat).MaxValue;
                StatBar.value = creature.GetState(thisStat).Value;
            }
        }
    }

    [SerializeField] private Sc_Creature myCreature;
    [SerializeField] private Text creatureName;
    [SerializeField] private Image displayCreaturePortrait;

    [Header("Grow Text")]
    [SerializeField] private float growStrength = 0.3f;

    [SerializeField] private float growDuration = 0.3f;

    [Header("Stats")]
    [SerializeField] private Text attackValue;

    [SerializeField] private Text defenseValue;
    [SerializeField] private StatInfo[] statsInfos = new StatInfo[2];

    private Dictionary<StatType, StatInfo> myInfos = new Dictionary<StatType, StatInfo>();

    // Start is called before the first frame update

    private void Start()
    {
        Sc_EventManager.instance.onUpdateStats.AddListener(SetInfo);
        displayCreaturePortrait.sprite = myCreature.profile.portrait;
        if (myCreature.GetComponent<Sc_Player>())
        {
            Sc_EventManager.instance.onGrowStat.AddListener(GrowStat);
        }

        SetInfo();
        foreach (var info in statsInfos)
        {
            myInfos.Add(info.thisStat, info);
        }
    }

    public void GrowStat(StatType stat)
    {
        Transform statText = null;
        if (myInfos.ContainsKey(stat))
        {
            statText = myInfos[stat].statValueText.transform;
        }
        else
        {
            switch (stat)
            {
                case StatType.Attack:
                    statText = attackValue.transform;
                    break;

                case StatType.Defense:
                    statText = defenseValue.transform;
                    break;
            }
        }
        Vector3 baseScale = statText.localScale;
        if (statText.transform.localScale.x > baseScale.x)
        {
            statText.transform.localScale = baseScale;
        }
        DOTween.Kill(statText);
        statText.DOComplete();
        statText.DOScale(baseScale * growStrength, growDuration);
        statText.DOScale(baseScale, growDuration / 2).SetDelay(growDuration);
    }

    public void SetInfo()
    {
        foreach (var item in statsInfos)
        {
            item.UpdateDisplay(myCreature);
        }
        creatureName.text = myCreature.profile.name;
        attackValue.text = myCreature.GetAttack.Value + "";
        defenseValue.text = myCreature.GetDefense.Value + "";
    }
}