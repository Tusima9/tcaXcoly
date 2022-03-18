using UnityEngine;

public class StageInfo
{
    public Game[] games;
}

[System.Serializable]
public class Game
{
    public string name;
    public string gameId;
    public WaveList[] waveLists;
}

[System.Serializable]
public class WaveList
{
    public EnemyData[] enemyData;
}

[System.Serializable]
public class EnemyData
{
    public string spriteId;
    public int enemyId;
    public float enemyHp;
    public int enemyAttack;
    public int enemyDefence;
}


public class StageDataJsonReader : MonoBehaviour
{
    [SerializeField] private TextAsset gameDataJson;
    [SerializeField] private EnemyDataManager EnemyDataManager;

    private StageInfo stageData;

    void Awake( )
    {
        stageData = JsonUtility.FromJson<StageInfo>( gameDataJson.text );

        foreach( Game info in stageData.games )
        {
            Debug.Log( "name: " + info.name );
            Debug.Log( "gameId: " + info.gameId );

            Debug.Log( "w1-e1-id: " + info.waveLists[0].enemyData[0].spriteId );
            Debug.Log( "w1-e1-id: " + info.waveLists[0].enemyData[0].enemyId );
            Debug.Log( "w1-e2-id: " + info.waveLists[0].enemyData[1].spriteId );
            Debug.Log( "w1-e2-id: " + info.waveLists[0].enemyData[1].enemyId );
            Debug.Log( "w1-e3-id: " + info.waveLists[0].enemyData[2].spriteId );
            Debug.Log( "w1-e3-id: " + info.waveLists[0].enemyData[2].enemyId );

            Debug.Log( "w2-e1-id: " + info.waveLists[1].enemyData[0].spriteId );
            Debug.Log( "w2-e1-id: " + info.waveLists[1].enemyData[0].enemyId );
        }
    }

    public void RequestData( int gameid, int waveNum )
    {
        for( int i = 0; i < 3; i++ )
        {
            if( i < stageData.games[gameid].waveLists[waveNum].enemyData.Length )
            {
                EnemyData tempEnemy = stageData.games[gameid].waveLists[waveNum].enemyData[i];
                EnemyDataManager.SetEnemyData( i,
                                               tempEnemy.spriteId, tempEnemy.enemyId, tempEnemy.enemyHp,
                                               tempEnemy.enemyAttack, tempEnemy.enemyDefence );
            }
            else
            {
                EnemyDataManager.DeactivateEnemy( i );
            }
        }
    }

    public int GetMaxWave( int id )
    {
        return stageData.games[id].waveLists.Length;
    }
}
