using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private GameManager GameManager;
    [SerializeField] private int selfNum;

    private void Start( )
    {
        GameManager = FindObjectOfType<GameManager>( );
        selfNum = transform.parent.GetSiblingIndex( );
    }

    //ターゲット変更
    private void OnMouseDown( )
    {
        GameManager.ChangeTargetEnemy( selfNum );
    }
}
