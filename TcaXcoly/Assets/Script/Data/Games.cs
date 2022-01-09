using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public static class Games // data class concerning loading and giving away game data involving stages
    {
        private static Game[] loadedGames;

        private static readonly string gameDataJson = "game";

        public static void LoadGame()
        {
            //load json
            TextAsset jsonAsset = Resources.Load("Data/" + gameDataJson) as TextAsset;
            string json = jsonAsset.ToString();
            GameJson loadedData = JsonUtility.FromJson<GameJson>(json);
            //store the loaded array
            loadedGames = loadedData.games;
        }

        public static string GetGameName(int gameIndex)
        {
            return loadedGames[gameIndex].gameName;
        }

        public static int GetMaxStage(int gameIndex)
        {
            return loadedGames[gameIndex].stages.Length;
        }

        public static Stage GetStage(int gameIndex, int stageIndex)
        {
            return loadedGames[gameIndex].stages[stageIndex];
        }

        //public static int  GetGameMaxRound(int gameIndex)
        //{
        //    return loadedGames[gameIndex].maxAllowedTurn;
        //}

        public static string GetUUID(int gameIndex)
        {
            return loadedGames[gameIndex].gameUUID;
        }
    }

    [Serializable]
    public struct GameJson
    {
        public Game[] games;// array of all the possible game
    }

    [Serializable]
    public struct Game //format of 1 game
    {
        public string gameName; // game name displayed

        //   public int maxAllowedTurn; // max number of turn allowed in this round --> may not be used

        public Stage[] stages; // detail of stages that occur in the game

        public string gameUUID; // uuid of the game
    }

    [Serializable]
    public struct Stage
    {
        public string EnemyID; //sprite ID for the enemy

        public int enemyHP; //  hp for kill this enemy

        public int enemyAttack;

        public int enemyDefence;

        public int turnBeforeAttack;
    }
}