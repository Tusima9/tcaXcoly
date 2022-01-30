using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Script.MemberSelection
{
    public class Confirm : MonoBehaviour
    {
        public void onClick()
        {
            //change it later!!!!
            EnemyStageManager.SetIdWave( 0, 0 );

            if (Coordinator.TeamManager.GetMembers().Count!=0)
            {
                StartCoroutine(LoadPuzzleGame());
            }
            else
            {
                Debug.Log("no character chosen");
            }
        }
        IEnumerator LoadPuzzleGame()
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Puzzle");
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }
}