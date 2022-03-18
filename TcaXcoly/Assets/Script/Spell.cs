using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public enum SpellType
{
    Copy,
    HotFever,
    DefDown,
}

public abstract class Spell : MonoBehaviour
{
    public abstract SpellType spellType { get; }
    protected GameManager gameManager;
    protected Grid grid;
    [SerializeField] protected float turnBeforeSpellAwalable;
    protected Sc_Player player;
    private Button SpellButton;
    private Text TurnBeforeReady;

    public void Awake()
    {
        TurnBeforeReady = GetComponentInChildren<Text>();
        player = FindObjectOfType<Sc_Player>();
        gameManager = FindObjectOfType<GameManager>();
        grid = FindObjectOfType<Grid>();
        SpellButton = GetComponent<Button>();
    }

    public virtual void start()
    {
        TurnBeforeReady.text = turnBeforeSpellAwalable + "";
        Sc_EventManager.instance.onUpdateStats.AddListener(UpdateUI);
    }

    public void UpdateUI()
    {
        // SpellButton.interactable = (player.GetSkill.Value == turnBeforeSpellAwalable) >= 0 && gameManager.canPlay && grid.SwapPieces;
    }
}