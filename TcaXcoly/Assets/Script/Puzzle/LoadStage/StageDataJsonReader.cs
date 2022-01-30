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
    public float enemyHp;
    public int enemyAttack;
    public int enemyDefense;
}


public class StageDataJsonReader : MonoBehaviour
{
    [SerializeField] private TextAsset gameDataJson;
    [SerializeField] private EnemyDataManager EnemyDataManager;

    private StageInfo stageData;

    void Awake( )
    {
        stageData = JsonUtility.FromJson<StageInfo>( gameDataJson.text );
    }

    public void RequestData( int gameid, int waveNum )
    {
        for( int i = 0; i < stageData.games[gameid].waveLists[0].enemyData.Length; i++ )
        {
            EnemyData tempEnemy = stageData.games[gameid].waveLists[0].enemyData[i];
            EnemyDataManager.SetEnemyData( i,
                                           tempEnemy.spriteId, tempEnemy.enemyHp,
                                           tempEnemy.enemyAttack, tempEnemy.enemyDefense );
        }
    }
}
