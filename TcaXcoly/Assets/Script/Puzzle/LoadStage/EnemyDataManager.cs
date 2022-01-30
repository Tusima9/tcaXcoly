using UnityEngine;

public class EnemyDataManager : MonoBehaviour
{
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

    public void SetEnemyData( int index, string name, float hp, int atk, int def )
    {
        enemies[index].SetData( name, hp, atk, def );
        enemies[index].gameObject.SetActive( true );
    }

    public void DeactivateEnemy( int pos )
    {
        Destroy( enemies[pos].gameObject );
    }
}
