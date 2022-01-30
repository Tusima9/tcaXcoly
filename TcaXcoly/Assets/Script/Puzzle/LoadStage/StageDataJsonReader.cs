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
    public int enemyHp;
    public int enemyAttack;
    public int enemyDefense;
}


public class StageDataJsonReader : MonoBehaviour
{
    [SerializeField] private TextAsset gameDataJson;

    // Start is called before the first frame update
    void Start( )
    {
        StageInfo stageData = JsonUtility.FromJson<StageInfo>( gameDataJson.text );

        foreach( Game info in stageData.games )
        {
            Debug.Log( "name: " + info.name );
            Debug.Log( "gameId: " + info.gameId );

            Debug.Log( "w1-e1-id: " + info.waveLists[0].enemyData[0].spriteId );
            Debug.Log( "w1-e1-hp: " + info.waveLists[0].enemyData[0].enemyHp );
            Debug.Log( "w1-e1-atk: " + info.waveLists[0].enemyData[0].enemyAttack );
            Debug.Log( "w1-e1-def: " + info.waveLists[0].enemyData[0].enemyDefense );


            Debug.Log( "w1-e2-id: " + info.waveLists[0].enemyData[1].spriteId );
            Debug.Log( "w1-e2-hp: " + info.waveLists[0].enemyData[1].enemyHp );
            Debug.Log( "w1-e2-atk: " + info.waveLists[0].enemyData[1].enemyAttack );
            Debug.Log( "w1-e2-def: " + info.waveLists[0].enemyData[1].enemyDefense );


            Debug.Log( "w1-e3-id: " + info.waveLists[0].enemyData[2].spriteId );
            Debug.Log( "w1-e3-hp: " + info.waveLists[0].enemyData[2].enemyHp );
            Debug.Log( "w1-e3-atk: " + info.waveLists[0].enemyData[2].enemyAttack );
            Debug.Log( "w1-e3-def: " + info.waveLists[0].enemyData[2].enemyDefense );


            Debug.Log( "w2-e1-id: " + info.waveLists[1].enemyData[0].spriteId );
            Debug.Log( "w2-e1-hp: " + info.waveLists[1].enemyData[0].enemyHp );
            Debug.Log( "w2-e1-atk: " + info.waveLists[1].enemyData[0].enemyAttack );
            Debug.Log( "w2-e1-def: " + info.waveLists[1].enemyData[0].enemyDefense );
        }

    }
}
