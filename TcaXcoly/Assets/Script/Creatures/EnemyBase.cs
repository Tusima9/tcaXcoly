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

    private void OnMouseDown( )
    {
        GameManager.ChangeTargetEnemy( selfNum );
    }
}
