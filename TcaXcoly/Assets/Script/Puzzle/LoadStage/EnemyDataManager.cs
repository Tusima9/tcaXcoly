using UnityEngine;

public class EnemyDataManager : MonoBehaviour
{
    [SerializeField] private StageDataJsonReader StageDataJsonReader;
    [SerializeField] private EnemyStat[] enemies = new EnemyStat[3];

    private void Start( )
    {
        //change the stage and wave hv to load here
        StageDataJsonReader.RequestData( 0, 0 );
    }

    public void SetEnemyData( int pos, string name, float hp, int atk, int def )
    {
        enemies[pos].SetData( name, hp, atk, def );
    }

    public void DeactivateEnemy( int pos )
    {
        Destroy( enemies[pos].gameObject );
    }
}
