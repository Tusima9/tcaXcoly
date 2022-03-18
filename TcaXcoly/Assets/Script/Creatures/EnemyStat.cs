using UnityEngine;
using UnityEngine.UI;

public class EnemyStat : MonoBehaviour
{
    [SerializeField] private GameManager GameManager;
    [SerializeField] private EnemyData data;
    [SerializeField] private int selfNum;
    [SerializeField] private Animator animator;
    [SerializeField] private Slider life;
    [SerializeField] private Text hpText;
    public Gradient gradient;
    public Image fill;

    private void Start( )
    {
        selfNum = transform.GetSiblingIndex( );
        GameManager = FindObjectOfType<GameManager>( );
        animator = GetComponentInChildren<Animator>( );
    }

    public void SetData( string name, int id, float hp, int atk, int def )
    {
        data.spriteId = name;
        data.enemyId = id;
        data.enemyHp = hp;
        data.enemyAttack = atk;
        data.enemyDefence = def;

        life.maxValue = hp;

        UpdateSliderValue( );
    }

    public void ModifyHealth( float value )
    {
        data.enemyHp += value;

        if(data.enemyHp <= 0)
        {
            animator.SetBool( "isDead", true);
            gameObject.SetActive( false );
            Destroy( this.gameObject );
        }

        UpdateSliderValue( );

        Debug.Log( "Modified" );
    }

    private void UpdateSliderValue( )
    {
        life.value = data.enemyHp;
        fill.color = gradient.Evaluate(life.normalizedValue);
        fill.color = gradient.Evaluate(1f);
        hpText.text = data.enemyHp.ToString( );
    }

    private void OnDestroy( )
    {
        GameManager.EnemyDestroyed( selfNum );
    }
}
