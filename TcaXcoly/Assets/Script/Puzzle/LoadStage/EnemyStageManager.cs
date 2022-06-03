public static class EnemyStageManager
{
    private static int nowStageId = 0;
    private static int nowWave = 0;

    /// <summary>
    /// 現在のStage IDを取得
    /// </summary>
    public static int GetStageId( )
    {
        return nowStageId;
    }

    /// <summary>
    /// 現在のWave Numを取得
    /// </summary>
    public static int GetNowWave( )
    {
        return nowWave;
    }

    /// <summary>
    /// 現在のStage IDとWave Numをセット
    /// </summary>
    public static void SetIdWave( int id, int wave )
    {
        nowStageId = id;
        nowWave = wave;
    }
}
