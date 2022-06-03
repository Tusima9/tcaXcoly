using UnityEngine;

/// <summary>
/// Enemy全体のデータコントローラー
/// </summary>
public class EnemyDataManager : MonoBehaviour
{
    [SerializeField] private Sprite[] enemyImages;
    [SerializeField] private int stageId;
    [SerializeField] private int wave;
    [SerializeField] private StageDataJsonReader StageDataJsonReader;
    [SerializeField] private EnemyStat[] enemies = new EnemyStat[3];

    private void Start( )
    {
        stageId = EnemyStageManager.GetStageId( );
        wave = EnemyStageManager.GetNowWave( );
        StageDataJsonReader.RequestData( stageId, wave );
    }

    /// <summary>
    /// 個別のEnemyデータをjsonからセット
    /// </summary>
    public void SetEnemyData( int index, string name, int id, float hp, int atk, int def )
    {
        enemies[index].SetData( name, id, hp, atk, def );
        enemies[index].gameObject.SetActive( true );
        enemies[index].transform.GetChild( 1 ).GetComponent<SpriteRenderer>( ).sprite = enemyImages[id];
        
    }

    /// <summary>
    /// Enemyを消す
    /// </summary>
    /// <param name="pos">Enemy番号</param>
    public void DeactivateEnemy( int pos )
    {
        Destroy( enemies[pos].gameObject );
    }
}
