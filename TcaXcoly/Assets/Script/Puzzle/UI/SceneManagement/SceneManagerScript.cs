using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void JumpToMain( )
    {
        SceneManager.LoadSceneAsync( 1 );
    }

    public void JumpToScenario( )
    {
        SceneManager.LoadSceneAsync( 2 );
    }

    public void JumpToPuzzle()
    {
        SceneManager.LoadSceneAsync( 3 );
    }

    public void JumpToTitle( )
    {
        SceneManager.LoadSceneAsync( 0 );
    }

}
