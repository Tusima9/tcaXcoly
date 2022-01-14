using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    private Sc_Player currentPlayers;
    private Sc_Enemy currentEnemys;

    [SerializeField] private int maxActions = 1;
    private int remainingActions;

    [SerializeField]
    public Text displayActions;

    [SerializeField]
    public Text displayActions2;

    [SerializeField]
    public Text displayActions3;

    [SerializeField]
    public CanvasGroup yourTurn;

    [SerializeField]
    public GameObject endScreen;

    [SerializeField]
    public Text displayStageText;

    public bool canPlay = true;
    private Image screen;
    private Text text;

    private void Awake()
    {
        currentPlayers = FindObjectOfType<Sc_Player>();
        currentEnemys = FindObjectOfType<Sc_Enemy>();
        remainingActions = maxActions;
        displayActions.text = currentEnemys.TurnLeftBeforeAction + "";
        displayActions2.text = currentEnemys.TurnLeftBeforeAction + "";
        displayActions3.text = currentEnemys.TurnLeftBeforeAction + "";
        yourTurn.DOFade(0, 0);

        screen = endScreen.GetComponentInChildren<Image>();
        text = endScreen.GetComponentInChildren<Text>();
        endScreen.GetComponentInChildren<Image>().DOFade(0, 0);
        endScreen.GetComponentInChildren<Text>().DOFade(0, 0);
    }

    private void Start()
    {
        Sc_EventManager.instance.onWin.AddListener(GameOver);
        //  Sc_EventManager.instance.OnSpellInvocation.AddListener(InvokeSpell);
    }

    //private void InvokeSpell(SpellType spellName)
    //{
    //    StartCoroutine(SpellAnimation(spellName));
    //}

    //public IEnumerator SpellAnimation(SpellType spellName)
    //{
    //    canPlay = false;
    //    Sc_EventManager.instance.onUpdateStats.Invoke();
    //    Sequence sequence = DOTween.Sequence();
    //    switch (spellName)
    //    {
    //        case SpellType:
    //            break;
    //    }
    //}

    public void GameOver(bool win)
    {
        screen.color = new Color(0, 0, 0, 0);
        screen.DOFade(0.5f, 0.8f);
        text.DOFade(1, 0.3f).SetDelay(0.3f);

        if (win)
            text.text = "Victory !";
        else
            text.text = "Game Over...";
    }

    public void ChangeAction(int amount)
    {
        if (canPlay)
            remainingActions += amount;

        if (remainingActions <= 0)
        {
            remainingActions = maxActions;
            remainingActions = currentEnemys.TurnLeftBeforeAction;
            StartCoroutine(LaunchTurn(currentPlayers, currentEnemys));
        }

        displayActions.text = remainingActions + "";
        displayActions2.text = remainingActions + "";
        displayActions3.text = remainingActions + "";
    }

    public IEnumerator LaunchTurn(Sc_Player firstOpponent, Sc_Enemy secondOpponent)
    {
        canPlay = false;
        Sc_EventManager.instance.onUpdateStats.Invoke();
        Vector3 baseScale = yourTurn.transform.localScale;
        float delay = 2f;
        yourTurn.DOFade(1, 0.3f);
        yourTurn.transform.DOScale(baseScale * 1.5f, delay);
        yield return new WaitForSeconds(delay);

        float wait = 3f;
        firstOpponent.StartAttack(secondOpponent);
        yield return new WaitForSeconds(wait);
        if (!secondOpponent.isDead)
        {
            if (currentEnemys.TurnLeftBeforeAction <= 0)
            {
                secondOpponent.StartAttack(firstOpponent);
            }
            yield return new WaitForSeconds(wait);
        }
        yourTurn.DOFade(0, delay - 0.3f);
        yourTurn.transform.DOScale(baseScale, 0).SetDelay(delay - 0.3f);
        yield return new WaitForSeconds(delay - 0.3f);
        canPlay = true;
    }
}