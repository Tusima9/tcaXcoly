public static class EnemyStageManager
{
    private static int nowStageId = 0;
    private static int nowWave = 0;

    public static int GetStageId( )
    {
        return nowStageId;
    }

    public static int GetNowWave( )
    {
        return nowWave;
    }

    public static void SetIdWave( int id, int wave )
    {
        nowStageId = id;
        nowWave = wave;
    }
}
