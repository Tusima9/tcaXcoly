using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    private void Start()
    {
        Vector3 cameraRightMiddle = Camera.main.ViewportToWorldPoint(new Vector2(1f, 0.5f));
        cameraRightMiddle.z = transform.position.z;
        transform.position = cameraRightMiddle;
    }
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
