using UnityEngine;
using UnityEngine.UI;

public class EnemyStat : MonoBehaviour
{
    [SerializeField] private EnemyData data;
    [SerializeField] private Animator animator;
    [SerializeField] private Slider life;
    [SerializeField] private Text hpText;

    private void Start( )
    {
        animator = GetComponentInChildren<Animator>( );
    }

    public void SetData( string name, float hp, int atk, int def )
    {
        data.spriteId = name;
        data.enemyHp = hp;
        data.enemyAttack = atk;
        data.enemyDefense = def;

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
        hpText.text = data.enemyHp.ToString( );
    }
}
