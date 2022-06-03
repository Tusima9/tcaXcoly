using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Sc_Player currentPlayers;

    [SerializeField] private StageDataJsonReader jsonReader;
    [SerializeField] private int nowStageId;
    [SerializeField] private int nowWave;

    [SerializeField] private Sc_Enemy[] currentEnemies;
    [SerializeField] private Sc_Enemy target;
    [SerializeField] private Transform targetFrame;
    [SerializeField] private Vector3[] framePos;

    [SerializeField] private int maxActions = 1;
    private int remainingActions;

    [SerializeField]
    public Text[] displayActions;

    [SerializeField]
    public CanvasGroup yourTurn;

    [SerializeField]
    public GameObject endScreen;

    [SerializeField]
    public Text displayStageText;

    public bool canPlay = true;
    private Image screen;
    private Text text;

    //change it to type later
    [SerializeField] List<int> matchesList = new List<int>( );

    private void Awake()
    {
        nowStageId = EnemyStageManager.GetStageId( );
        nowWave = EnemyStageManager.GetNowWave( );

        currentPlayers = FindObjectOfType<Sc_Player>();
        target = currentEnemies[0];
        ChangeTargetFramePos( 0 );

        remainingActions = maxActions;

        for(int i=0;i<3;i++ )
        {
            displayActions[i].text = currentEnemies[i].TurnLeftBeforeAction + "";
        }

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
            remainingActions = target.TurnLeftBeforeAction;
            StartCoroutine(LaunchTurn(currentPlayers, target));
        }

        for( int i = 0; i < 3; i++ )
        {
            if(displayActions[i] != null)
            {
                displayActions[i].text = currentEnemies[i].TurnLeftBeforeAction + "";
            }
        }
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

        //計算開始
        Debug.Log( "StartCalculate" );

        //playerのダメージを取得
        float playerDmg = firstOpponent.GetAttack.Value;
        float puzzleBonus = 1.1f;

        //caution -> 今はタイプがない
        float typeBonus = 1;

        //マッチしたリストをゲット
        for( int i = 0; i < matchesList.Count; i++ )
        {
            //タイプ計算もここでする
            //マッチした数でボーナスが増える
            puzzleBonus += 0.1f;
        }

        Debug.Log( playerDmg + " " + puzzleBonus + " " + typeBonus );

        //ダメージ計算
        playerDmg = playerDmg * puzzleBonus * typeBonus;

        //攻撃
        firstOpponent.StartAttack(secondOpponent, playerDmg );
        yield return new WaitForSeconds(wait);

        //エネミーが死んでないなら防御を計算
        if (!secondOpponent.isDead)
        {
            if (target.TurnLeftBeforeAction <= 0)
            {
                float enemyDmg = secondOpponent.GetAttack.Value - firstOpponent.GetDefense.Value;
                secondOpponent.StartAttack( firstOpponent, enemyDmg );
            }
            yield return new WaitForSeconds(wait);
        }

        //エネミーが死んだ！
        if (secondOpponent.isDead)
        {
            Destroy(secondOpponent);
        }

        yourTurn.DOFade(0, delay - 0.3f);
        yourTurn.transform.DOScale(baseScale, 0).SetDelay(delay - 0.3f);
        yield return new WaitForSeconds(delay - 0.3f);
        canPlay = true;
    }

    public void AddToMatchesList( int type )
    {
        matchesList.Add( type );
    }

    public void ClearMatchesList( )
    {
        matchesList.Clear( );
    }

    /// <summary>
    /// ターゲットを変更
    /// </summary>
    public void ChangeTargetEnemy( int index )
    {
        target = currentEnemies[index];
        Debug.Log( "Current Target: " + index + target );
        ChangeTargetFramePos( index );
    }

    //ターゲット指定のフレーム位置を変更
    private void ChangeTargetFramePos( int index )
    {
        targetFrame.localPosition = framePos[index];
        targetFrame.gameObject.SetActive( true );
    }

    //Enemyが消したらの処理
    public void EnemyDestroyed( int index )
    {
        currentEnemies[index] = null;
        target = null;

        for( int i = 0; i < 3; i++ )
        {
            //ターゲット変更
            if( currentEnemies[i] != null)
            {
                target = currentEnemies[i];
                Debug.Log( "Current Target: " + i + target );
                ChangeTargetFramePos( i );
                return;
            }
        }

        //現在のエネミーが全部消されたら、次のWaveかステージをロード
        Debug.Log( "All Destroyed" );

        if( jsonReader.GetMaxWave( nowStageId ) - 1 > nowWave )
        {
            SoundSystem.instance.PlayBossBGM();
            EnemyStageManager.SetIdWave( nowStageId, nowWave + 1 );
            StartCoroutine( LoadScene( 3 ) );
        }
        else
        {
            EnemyStageManager.SetIdWave( nowStageId + 1, 0 );
            StartCoroutine( LoadScene( 4 ) );
            

        }
    }

    IEnumerator LoadScene( int sceneNum )
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync( sceneNum );
        while( !asyncLoad.isDone )
        {
            yield return null;
        }
    }
}